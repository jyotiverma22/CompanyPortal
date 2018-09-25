
    
function jqgridInitialize(status) {
    debugger
    $("#grid").setGridParam({ datatype: 'json', url: "/ProjectJQGrid/GetProjects?status=" + status});
    
    $("#grid").trigger("reloadGrid")

    $("#grid").jqGrid(
        {
            url: "/ProjectJQGrid/GetProjects?status=" + status,
            datatype: "json",
            mtype: "Get",
            postData:"", 
            colNames: ['Project Name', 'Manager Id', 'Status','Actions'],
            colModel: [
                {
                  key: false, name: 'Project_Name', index: 'Project_Name', editable: true, search: true
                    , searchoptions: { sopt: ['cn'] }, sortable: true,sorttype:'text'
                },
                { key: false, name: 'Mgr_Id', index: 'Mgr_Id', editable: true, search: true, searchtype: 'string', sortable: true, firstsortorder: 'desc', sorttype: 'text'},
                { key: false, name: 'Status', index: 'Status', editable: true, search: true, searchtype: 'string', sortable: true, sorttype: 'text' },
                { key: false, name: 'Actions', index: 'Actions', editable: false, formatter: displayButtons, search:false }

            ],
            pager: jQuery('#pager') ,           
            searchfield: "Project_Name",          
            rowList: [5, 10, 15, 20],
            height: "100%",
            viewrecords: true,
            caption: "Project Details",
            emptyrecords: "No projects to show",            
            loadOnce: true,
            multiselect:true,

            onSortCol: function (name, index,order) {
                debugger
                $("#grid").setGridParam({ postData: { "SortBy": name, "OrderBy":order } });
                s = $("#grid").getGridParam('selarrrow');
                $("#grid").jqGrid('setSelection', 1,true)
                alert(s);
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
            }


        });

    $("#grid").jqGrid('filterToolbar', {
        
        searchOperators: true,
        stringResult: true,
        searchOnEnter: true

    });

    jQuery("#grid").jqGrid('navGrid', '#pager', { del: false, add: false, edit: false, search: false });

    var maxNameLength = 10;
    $("input[id=gs_Project_Name]").keypress(function (e) {
        debugger
        var key = e.charCode || e.keyCode || 0;
        if (key === $.ui.keyCode.ENTER) {
            var $th = $(this).closest(".ui-search-toolbar>th"),
                colIndex = $th[0].cellIndex,
                $colHeader = $th.parent().siblings(".ui-jqgrid-labels").children("th").eq(colIndex),
                colHeaderText = $colHeader.children("div").text();
            var searchString = $(this).val();

            $("#grid").setGridParam({ datatype: 'json', mtype: "POST", postData: { "SearchField": colHeaderText, "SearchString": searchString } }).trigger("reloadGrid");


            if (this.value.length > maxNameLength) {
                alert(colHeaderText + ' is longer than ' + maxNameLength + ' characters.');
            }

        }
    });


}
// the event handler on expanding parent row receives two parameters
// the ID of the grid tow  and the primary key of the row
function showChildGrid(parentRowID, parentRowKey) {
    debugger
  
    // create unique table and pager
    var childGridID = parentRowID + "_table";
    var childGridPagerID = parentRowID + "_pager";

    // send the parent row primary key to the server so that we know which grid to show
    var childGridURL = "/ProjectJQGrid/getTeamDetails?pid=" + parentRowKey;
    // add a table and pager HTML elements to the parent grid row - we will render the child grid here
    $('#' + parentRowID).append('<table id=' + childGridID + '></table><div id=' + childGridPagerID + '></div>');
  //  $("#" + childGridID).setGridParam({ datatype: 'json', url: childGridID }).trigger("reloadGrid");

    $("#" + childGridID).jqGrid({
        url: childGridURL,
        mtype: "GET",
        datatype: "json",
        page: 1,
        colNames: ['UserId', 'EmployeeName', 'EmailId'],
        colModel: [
            { label: 'userId', name: 'userId', key: true, width: 75 },
            { label: 'Firstname', name: 'Firstname', width: 100 },
            { label: 'Email', name: 'Email', width: 100 }
        ],
        
        width: 500,
        height: '100%',
        rowNum: 5,
        pager: "#" + childGridPagerID,
        caption: "Team Details",
        emptyrecords: "No projects to show",
        onSelectRow: exapandEmployeeDetail,
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
    });
}

//custom formator function to display the Links
function displayButtons(cellvalue, options, rowObject) {
    var edit = "<a href='#'>Edit</a>",
        Details = "<a href='#'>Details</a> |",
        Delete = "<a href='#'>Delete</a>";
    return edit + Details + Delete;
}


function ToggleColumn(role_) {
    if (role_ == "Member") {
        jQuery("#grid").jqGrid('hideCol', ["Actions"]);
    }
    else if (role_ == "Admin") {
        jQuery("#grid").jqGrid('showCol', ["Actions"]);    
    }
}

