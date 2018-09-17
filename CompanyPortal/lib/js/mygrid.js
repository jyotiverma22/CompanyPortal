$("#grid").jqGrid(

    {

        url: "/LoggedIn/GetProjects",

        datatype: "json",
        mtype: "Get",
        colNames: ['PId', 'Project_Name', 'Mgr_Id', 'Status'],
        colModel: [
            { key: true, name: 'PId', index: 'PId', editable: false },
            { key: false, name: 'Project_Name', index: 'Project_Name', editable: true },
            { key: false, name: 'Mgr_Id', index: 'Mgr_Id', editable: true },
            { key: false, name: 'Status', index: 'Status', editable: true }


        ],
        pager: jQuery('#pager'),
        rowNum: 5,
        rowList: [5, 10, 15, 20],
        height: "100%",
        viewrecords: true,
        caption: "Project Details",
        emptyrecords: "No projects to show",
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,


    }).navGrid('#pager', { edit: true, add: true, del: true, search: true, refresh: true });
