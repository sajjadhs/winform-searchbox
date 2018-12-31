# Great Windows Forms Seach Box For DatagridView

---------------------------------------

Easily Seaches in DatagridView just by 1 Line Of Code...

```
dataGridView1.DataSource = searchBox1.searchResult(_data);  
```
### Prerequisites 

You fill comboBox with Column names by calling methods in 3 ways which you need:


```
searchBox1.SetCmboBoxDataSource(dataGridView1);

//or 

searchBox2.SetSetCmboBoxDataSourceByType(typeof(Data));

//or

searchBox3.SetCmboBoxDataSource(colsNameList);
```

See Example for more information... easy to understand.


then, just Implement "SearchBoxDelegate" in you forms:
```
public void Searching(object sender,string keyword)
        {
            var sndr = sender as SearchBox;
            if(sndr == searchBox1)
            {
                dataGridView1.DataSource = searchBox1.searchResult(_data);   
            } 
        }
```

Congratulations :) Done! ...


## License
[MIT](LICENSE)
