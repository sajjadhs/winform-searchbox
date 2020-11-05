# Great Windows Forms Search Box For DatagridView

---------------------------------------

Easily Searches in DatagridView just by few lines of code... 



```
dataGridView1.DataSource = searchBox1.searchResult(_data);  
```
![app Preview](https://github.com/shoseinpoor/winform-searchbox/blob/master/preview.png)


## Open Source

You can change any line of code or design of searchBox easily



### Setup to SearchBox

1- Add SearchBox control to your windows-form project,
2- Drag and drop the control to the form,
3- Fill your gridVeiw(optional), then use one of below codes to get the gridview columns

```
searchBox1.SetCmboBoxDataSource(dataGridView1);

//or 

searchBox2.SetSetCmboBoxDataSourceByType(typeof(Data));

//or

searchBox3.SetCmboBoxDataSource(colsNameList);
```

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

See Example for more information... easy to understand.

Congratulations :) Done! ...


## License
[MIT](LICENSE)
