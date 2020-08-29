$(document).ready(function () {
    var table = $("#example").DataTable({
        "paging": false,
        "processing": true, 
        "serverSide": true, 
        "filter": false,  
        "ajax": {
            "url": "/Home/PageData",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "name": "ID", "autoWidth": true },
           // { "data": "name", "name": "Name", "autoWidth": true },
            {
                "data": "name", "render": function (data, type, row, meta) {
                    return "<a href='/DemoGrid/Edit/" + row.name + "' class='btn btn-info'>Delete</a>";
                }
            }
        ]

    });


    setInterval(function () {
        table.ajax.reload();
    }, 1000);
});

function DeleteData(CustomerID) {
    alert("Something Went Wrong!" + CustomerID);
}  

