﻿@model IEnumerable<Eracker.Models.Report>
    @{
    ViewData["Title"] = "My Expense Tracker";
    }
    <link href="~/lib/bootstrap/dist/css/bootstrap.css" rel="stylesheet" />
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="~/lib/bootstrap/dist/js/bootstrap.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/js/bootstrap-datepicker.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/css/bootstrap-datepicker.css" rel="stylesheet">

    <h2>My Expense Manager</h2>
    <br />
    <div>
        <div style="float:left">
            <button class="btn btn-primary" onclick="AddEditExpenses(0)">Add Expense</button>
            <button class="btn btn-success" onclick="ReportExpense()">Expense Report</button>
        </div>
        <div style="float:right; width:40%;">
            <form asp-controller="Expense" asp-action="Index" class="form-group">
                <div class="col-sm-6">
                    <input class="form-control" type="text" name="SearchString" placeholder="Search">
                </div>
                <button type="submit" class="btn btn-default btn-info">Filter</button>
            </form>
        </div>
    </div>
    <br />
    <br />
    <table class="table">
        <thead>
            <tr>
                <th>@Html.DisplayNameFor(model => model.ItemId)</th>
                <th>@Html.DisplayNameFor(model => model.ItemName)</th>
                <th>@Html.DisplayNameFor(model => model.Amount)</th>
                <th>@Html.DisplayNameFor(model => model.ExpenseDate)</th>
                <th>@Html.DisplayNameFor(model => model.Category)</th>
                <th>Action Item</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var item in Model)
            {
            <tr>
                <td>@Html.DisplayFor(modelItem => item.ItemId)</td>
                <td>@Html.DisplayFor(modelItem => item.ItemName)</td>
                <td>@Html.DisplayFor(modelItem => item.Amount)</td>
                <td>@Html.DisplayFor(modelItem => item.ExpenseDate)</td>
                <td>@Html.DisplayFor(modelItem => item.Category)</td>
                <td>
                    <button class="btn btn-default" onclick="AddEditExpenses(@item.ItemId)">Edit</button>
                    <button class="btn btn-danger" onclick="DeleteExpense(@item.ItemId)">Delete</button>
                </td>
            </tr>
            }
        </tbody>
    </table>

    <div class="modal fade" id="expenseFormModel" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <a href="#" class="close" data-dismiss="modal">&times;</a>
                    <h3 id="title" class="modal-title">Add Expense</h3>
                </div>
                <div class="modal-body" id="expenseFormModelDiv">
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="expenseReportModal" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <a href="#" class="close" data-dismiss="modal">&times;</a>
                    <h3 class="modal-title">Expense Report</h3>
                </div>
                <div class="modal-body" id="expenseReportModalDiv">
                </div>
            </div>
        </div>
    </div>

    <script>

    var AddEditExpenses = function (itemId) {
        var url = "/Expense/AddEditExpenses?itemId=" + itemId;
        if (itemId > 0)
            $('#title').html("Edit Expense");

        $("#expenseFormModelDiv").load(url, function () {
            $("#expenseFormModel").modal("show");

        });

        $('#expenseFormModel').on('shown.bs.modal', function () {

            $('#calender-container .input-group.date').datepicker({
                todayBtn: true,
                calendarWeeks: true,
                todayHighlight: true,
                autoclose: true,
                container: '#expenseFormModel modal-body'
            });

        });
    }

    var ReportExpense = function () {
        var url = "/Expense/ExpenseSummary";

        $("#expenseReportModalDiv").load(url, function () {
            $("#expenseReportModal").modal("show");
        })
    }

    var DeleteExpense = function (itemId) {

        var ans = confirm("Do you want to delete item with Item Id: " + itemId);

        if (ans) {
            $.ajax({
                type: "POST",
                url: "/Expense/Delete/" + itemId,
                success: function () {
                    window.location.href = "/Expense/Index";
                }
            })
        }
    }
    </script>

    <script>

    $('body').on('click', "#btnSubmit", function () {
        var myformdata = $("#expenseForm").serialize();

        $.ajax({
            type: "POST",
            url: "/Expense/Create",
            data: myformdata,
            success: function () {
                $("#myModal").modal("hide");
                window.location.href = "/Expense/Index";
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        })
    })
    </script>

