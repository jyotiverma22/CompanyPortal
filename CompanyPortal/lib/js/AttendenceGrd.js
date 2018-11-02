

function AttendencejqgridInitialize(status) {
    debugger
    $("#grid").setGridParam({ datatype: 'json', url: "/ProjectJQGrid/GetProjects?status=" + status, postData: { Search: false } });

    $("#search").val("");


    $("#grid").trigger("reloadGrid");


    $("#grid").jqGrid(
        {
            url: "/ProjectJQGrid/GetProjects?status=" + status,
            datatype: "json",
            mtype: "Get",
            postData: "",
            colNames: ['', '', 'Project Name', 'Manager Id', 'Status'],
            colModel: [
                { key: false, name: 'Actions', index: 'Actions', width: 15, align: "center", editable: false, formatter: displayButtons, search: false },
                {
                    key: true, name: 'PId', index: 'PId', width: 100, editable: false, editrules: {
                        required: true,
                        edithidden: true
                    },
                    hidden: true,
                    editoptions: {
                        dataInit: function (element) {
                            jq(element).attr("readonly", "readonly");
                        }
                    }
                },
                {
                    key: false, name: 'Project_Name', index: 'Project_Name', editable: true, search: true
                    , searchoptions: { sopt: ['cn'] }, sortable: true, sorttype: 'text'
                },
                { key: false, name: 'Mgr_Id', index: 'Mgr_Id', editable: true, search: true, searchtype: 'string', sortable: true, firstsortorder: 'desc', sorttype: 'text' },
                { key: false, name: 'Status', index: 'Status', editable: true, search: true, searchtype: 'string', sortable: true, sorttype: 'text', search: false }

            ],
            pager: jQuery('#pager'),
            rowList: [5, 10, 15, 20],
            rowNum: 20,
            height: "100%",
            viewrecords: true,
            caption: "Project Details",
            emptyrecords: "No projects to show",
            loadOnce: true,
            ignoreCase: true,


            onSortCol: function (name, index, order) {
                debugger
                $("#grid").setGridParam({ postData: { "SortBy": name, "OrderBy": order } });
                //s = $("#grid").getGridParam('selarrrow');
                // $("#grid").jqGrid('setSelection', 1,true)
                //  alert(s);
            },
            ondblClickRow: function (id) {
                debugger
            },


            jsonReader: {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: false,
                Id: "0"
            },
            autowidth: true,
            subGrid: true,
            subGridRowExpanded: showChildGrid,
            subGridOptions: {
                expandOnLoad: false
            },

            loadComplete: function () {
                debugger
                $("tr.jqgrow:odd").addClass('myAltRowClass');
                if (a == 0) {
                    $('.ui-jqgrid-title').after('<div id="jqGridButtonDiv"><input type="text" name="search" id="ProjectSearchID" onkeypress="EnterPressedOnSearchBox(event) "> <a href="#" onclick="SearchInProject()" class="fa fa-search" id="SearchButton"></a> </div>');

                    a = 1;
                }


            }

        });

}