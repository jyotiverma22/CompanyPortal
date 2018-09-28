
    
function jqgridInitialize(status) {
    debugger
    $("#grid").setGridParam({ datatype: 'json', url: "/ProjectJQGrid/GetProjects?status=" + status});
    
    $("#grid").trigger("reloadGrid");

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
                { key: false, name: 'Status', index: 'Status', editable: true, search: true, searchtype: 'string', sortable: true, sorttype: 'text',search:false },
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
            ignoreCase:true,
            multiselect:true,

            onSortCol: function (name, index,order) {
                debugger
                $("#grid").setGridParam({ postData: { "SortBy": name, "OrderBy":order } });
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
            }


        });

    $("#grid").jqGrid('filterToolbar', {

        searchOperators: true,
        stringResult: true,
        searchOnEnter: true,
        autoSearch: false,
        groupOp: "AND",
        beforeSearch: function () {
            debugger


            var rules = [], i, cm, postData = $("#grid").jqGrid("getGridParam", "postData"),
                colModel = $("#grid").jqGrid("getGridParam", "colModel");
                
        
            for (i = 0; i < colModel.length; i++) {
                cm = colModel[i];
                if (cm.search !== false && (cm.stype === undefined || cm.stype === "text")) {
                    rules.push({
                        field: cm.name,
                        op: "cn",
                        data:$.trim( $("input[id=gs_" + cm.name + "]").val())
                    });
                }
            }
            $("#grid").setGridParam({
                mtype: "POST", postData: {
                    "filters": {
                        groupOp: "OR",
                        rules: rules
                    },
                    _search:true
                }
            }).trigger("reloadGrid");

        },

        afterSearch: function(){
            /*var colModel = colModel = $("#grid").jqGrid("getGridParam", "colModel");
            for (var i = 0; i < colModel.length; i++) {
                $("input[id=gs_" + colModel[i].name + "]").val("");
            }*/
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
    var edit = "<a href='#' onclick='EditProjectDetail(this)'>Edit</a> | ",
        AddTeam = "<a href='#' onclick='AddTeamMembers(this)'>Add Team</a> | ",
        changeStatus = "<a href='#' onclick='ProjectChangeStatus(this)'>change Status</a>";
    return edit + AddTeam + changeStatus;
}


function ToggleColumn(role_) {
    if (role_ == "Member") {
        jQuery("#grid").jqGrid('hideCol', ["Actions"]);
    }
    else if (role_ == "Admin") {
        jQuery("#grid").jqGrid('showCol', ["Actions"]);    
    }
}

function EditProjectDetail(item) {
    debugger
    var rowid = $(item).closest("tr").attr("id");
    //  jQuery('#grid').editRow(rowid);
   // jQuery("#grid").jqGrid('editGridRow', rowid, { addCaption: "Edit row" });
    $("#editprojectdetaildialog").dialog({
        autoOpen: false,
        title: "Edit Project Details",
        modal: true,
        open: function (event, ui) {
            debugger
        },
        buttons: {
            "Close": function () {
                $(this).dialog("close");
            }
        }

    });

    $("#editprojectdetaildialog").dialog("open");


}

function AddTeamMembers(item) {
    var rowid = $(item).closest("tr").attr("id");

}

function ProjectChangeStatus(item) {
    var rowid = $(item).closest("tr").attr("id");

}