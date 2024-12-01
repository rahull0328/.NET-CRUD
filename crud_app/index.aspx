<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="crud_app.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CRUD APP</title>
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/custom.css" rel="stylesheet" />
    <link href="assets/css/dataTables.dataTables.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid py-2 py-2">
            <h1 class="d-flex align-items-center justify-content-center p-3 text-warning">CRUD APP Using ASP.NET</h1>
            <div class="row">
                <div class="col-md-6">
                    <div class="card p-4 shadow-sm">
                        <div class="row">
                            <div class="col text-center">
                                <h3>User Details</h3>
                            </div>
                        </div>

                        <hr class="my-3" />

                        <div class="row">
                            <div class="col-md-4">

                                <label>User Id</label>
                                <div class="form-group">
                                    <div class="input-group">

                                        <asp:TextBox ID="txt_id" runat="server" placeholder="Enter User Id" CssClass="form-control" />
                                        <asp:Button runat="server" ID="btnGo" Text="Go" CssClass="btn btn-secondary" />
                                    </div>
                                </div>

                                <br />
                            </div>

                            <div class="col-md-8">
                                <label>User Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txt_name" runat="server" placeholder="Enter User Name" CssClass="form-control" />
                                </div>
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-6">

                                <label>Email</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txt_email" runat="server" TextMode="Email" placeholder="Enter Email" CssClass="form-control" />
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label for="txt_name">Phone Number</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txt_phone" runat="server" placeholder="Enter Phone Number" CssClass="form-control" />
                                </div>
                            </div>

                        </div>

                        <br />

                        <div class="row">

                            <div class="col-md-12">

                                <label>Gender</label>
                                <div class="form-group">
                                    <asp:RadioButton runat="server" ID="rad_male" Text="Male" Checked="true" GroupName="gender" />&nbsp;&nbsp;&nbsp;
                                    <asp:RadioButton runat="server" ID="rad_female" Text="Female" GroupName="gender" />
                                </div>
                            </div>

                        </div>

                        <br />

                        <div class="row d-flex justify-content-center">
                            <div class="col-md-4 text-center">
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnInsert" Text="Add" CssClass="btn btn-primary w-100" OnClick="btnInsert_Click" />
                                </div>
                            </div>

                            <div class="col-md-4 text-center">
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnUpdate" Text="Update" CssClass="btn btn-success w-100" OnClick="btnUpdate_Click" />
                                </div>
                            </div>

                            <div class="col-md-4 text-center">
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnDelete" Text="Remove" CssClass="btn btn-danger w-100" OnClick="btnDelete_Click" />
                                </div>
                            </div>
                        </div>
                        <br />
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="row">
                        <div class="card p-4 shadow-sm">

                            <div class="row">
                                <div class="col text-center">
                                    <h3>Users List</h3>
                                </div>
                                <hr class="my-3" />
                            </div>

                            <div class="row">

                                <div class="col">
                                    <asp:SqlDataSource ID="viewData" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [data] ORDER BY [Id]">
                                    </asp:SqlDataSource>
                                    <asp:GridView runat="server" ID="gr_userData" CssClass="table table-striped table-bordered" AllowPaging="true" AllowSorting="true" DataSourceID="viewData">
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
    <script src="assets/js/bootstrap.bundle.min.js"></script>
    <script src="assets/js/jquery-3.6.0.min.js"></script>
    <script src="assets/js/dataTables.min.js"></script>

</body>
</html>
