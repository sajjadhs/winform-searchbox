
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_SearchBox
{
    public partial class Form1 : Form,SearchBoxDelegate
    {

        List<Data> _data = new List<Data>();
        public Form1()
        {
            InitializeComponent();

            _data.Add(new Data { ID = 1, Name = "Max Depp", Weight = 85.5 });
            _data.Add(new Data { ID = 2, Name = "Tom Tommi", Weight = 75.2 });
            _data.Add(new Data { ID = 3, Name = "Alice Thomson", Weight = 60 });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mode1();
            mode2();
            mode3();
        }

        private void mode3()
        {
            dataGridView3.Columns.Add("ID","User ID");
            dataGridView3.Columns.Add("Name", "User Name");
            dataGridView3.Columns.Add("Weight", "User Weight");
            foreach (var item in _data)
            {
                dataGridView3.Rows.Add(item.ID, item.Name, item.Weight);
            }

            List<SearchBox.ColNameText> colsNameList = new List<SearchBox.ColNameText>();
            foreach (DataGridViewColumn item in dataGridView3.Columns)
            {
                colsNameList.Add(new SearchBox.ColNameText { colname = item.Name, displaytext = item.HeaderText });
            }

            searchBox3.SetCmboBoxDataSource(colsNameList);
        }

        private void mode2()
        {
            dataGridView2.DataSource = _data;
            searchBox2.SetSetCmboBoxDataSourceByType(typeof(Data));
        }

        
        private void mode1()
        {
            dataGridView1.DataSource = _data;
            searchBox1.SetCmboBoxDataSource(dataGridView1);

        }

        public void Searching(object sender,string keyword)
        {
            var sndr = sender as SearchBox;

            if(sndr == searchBox1)
            {
                dataGridView1.DataSource = searchBox1.searchResult(_data);   
            }
            else if(sndr == searchBox2)
            {
                dataGridView2.DataSource = searchBox2.searchResult(_data);
            }
            else if(sndr == searchBox3)
            {
                var result = searchBox3.searchResult(_data);
                dataGridView3.Rows.Clear();
                foreach (var item in result)
                {
                    dataGridView3.Rows.Add(item.ID, item.Name, item.Weight);
                }
            }
            
        }

        class Data
        {
            [DisplayName("User ID")]
            public int ID { get; set; }
            [DisplayName("User Name")]
            public string  Name { get; set; }
            [DisplayName("User Weight")]
            public double Weight { get; set; }
        }
    }
}
