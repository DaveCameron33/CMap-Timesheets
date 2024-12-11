<b>2024-12-11 12:00</b>
Did this as a WinForm as that's where most of my experience lies - but I intend (hope) to update it to include an ASP web frontend fairly soon to prove (to  myself) that I can.
Wrote it as a TDD project to get some more experience of that - so it's entirely possible I've not followed that process correctly - and in doing so have had to change the way I do things, for instance, I would 'normally' loop through the DataTable/DataGridView, writing each row to the CSV - having already created ExtensionMethods to convert the Column/Row/Cell collections to comma-delimited strings. Here's some I did earlier:
![image](https://github.com/user-attachments/assets/1d50f7c7-669a-4073-80a3-962d295ee6fe)
Although these are specific to DataGridViews, it's easy enough to do the same for DataTables.

