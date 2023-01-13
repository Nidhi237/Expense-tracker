﻿@model Etracker.Models.Report

<script src="//cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.3.0/js/bootstrap-datepicker.js"></script>
<link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.8.0/css/bootstrap-datepicker.css" rel="stylesheet">

<div>
    <div class="row">
        <div class="col-md-8">
            <form id="expenseForm">
                <input type="hidden" asp-for="ItemId" />
                <div class="form-group">
                    <label asp-for="ItemName" class="control-label"></label>
                    <input asp-for="ItemName" class="form-control" />
                </div>
                <div class="form-group">
                    <label asp-for="Category" class="control-label"></label>
                    <select asp-for="Category" class="form-control">
                        <option value="">-- Select Category --</option>
                        <option value="Food">Food</option>
                        <option value="Shopping">Shopping</option>
                        <option value="Travel">Travel</option>
                        <option value="Health">Health</option>
                    </select>
                </div>
                <div class="form-group">
                    <label asp-for="Amount" class="control-label"></label>
                    <input asp-for="Amount" class="form-control" />
                </div>
                <div class="form-group" id="calender-container">
                    <label asp-for="ExpenseDate" class="control-label"></label>
                    <div class="input-group date">
                        <input asp-for="ExpenseDate" type="text" class="form-control"><span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
                    </div>
                </div>
                <div class="form-group">
                    <button type="button" id="btnSubmit" class="btn btn-block btn-info">Save</button>
                </div>
            </form>
        </div>
    </div>
</div>
