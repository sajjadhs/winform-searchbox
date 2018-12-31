using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace WinForm_SearchBox
{

    public interface SearchBoxDelegate
    {
        void Searching(object sender,string keyword);
    }

    public partial class SearchBox : UserControl
    {
        private SearchBoxDelegate _delegate;
        public SearchBox(SearchBoxDelegate _delegate)
        {
            InitializeComponent();
            this._delegate = _delegate;
        }


        public class ColNameText
        {
            public string colname { get; set; }
            public string displaytext { get; set; }
        }


        public void SetCmboBoxDataSource(List<ColNameText> data)
        {
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "displaytext";
        }
        /// <summary>
        /// انتخاب با نام اصلی خاصیت - نام فیلد
        /// </summary>
        /// <param name="name"></param>
        public void SetSelected_WithColName(string name)
        {
            List<ColNameText> l =(List<ColNameText>) comboBox1.DataSource;

            var w =l.Where(q => q.colname == name).FirstOrDefault();

            if(w!=null)
            comboBox1.SelectedItem = w;
        }

        public List<ColNameText> SetSetCmboBoxDataSourceByType(Type type)
        {
            List<ColNameText> data = new List<ColNameText>();
            foreach (var item in type.GetProperties())
            {
                //var propInfo = list.GetType().GetProperty(item.Name);
                var displayNameAttribute = item.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                try
                {
                    
                    var displayName = (displayNameAttribute.FirstOrDefault() as DisplayNameAttribute).DisplayName;
                    if (displayName != null || displayName != "")
                    {
                        data.Add(new ColNameText { colname = item.Name, displaytext = displayName });
                    }
                }
                catch { }
            }

            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "displaytext";

            return data;
        }
        public void SetCmboBoxDataSource(DataGridView dg)
        {

            List<ColNameText> data = new List<ColNameText>();
            foreach (DataGridViewColumn item in dg.Columns)
            {
                data.Add(new ColNameText() { colname=item.Name, displaytext = item.HeaderText });
            }
            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "displaytext";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        public List<T> searchResult<T>(List<T> list_data)
        {
            var q= (ColNameText) comboBox1.SelectedItem;
            var p = Expression.Parameter(typeof(T));
            if (q == null) return list_data;

            var lambda = Expression.Lambda<Predicate<T>>(Expression.Call(
                Expression.Call(Expression.PropertyOrField(p, q.colname), "ToString", null),
                "Contains", null, Expression.Constant(txtSearch.Text, typeof(string))), p);
            return list_data.FindAll(lambda.Compile());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            _delegate.Searching(this,txtSearch.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
