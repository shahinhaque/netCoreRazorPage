var dataTable;

$(document).ready(function () {
    LoadDataTable();
});


function LoadDataTable() {
    dataTable = $("#auth_dt").DataTable({

        "ajax": {
            "url": "/api/Author",
            "type": "Get",
            "datatype":"json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "origin", "width": "20%" },
            { "data": "description", "width": "20%" },
            //{ "data": "id", "width": "30%" }
            {
                "data": "id",
                "render": function (data) {
                    return `<div class='text-center'>
                            <a href="/Author/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px'>Edit</a>
                            &nbsp;
                            <a class='btn btn-danger text-white' style='cursor:pointer; width:100px'>Delete</a>
                        </div>`
                }
            },
            
        ],
        "language": {
            "emptyTable" : "No data found"
        }

    });
}