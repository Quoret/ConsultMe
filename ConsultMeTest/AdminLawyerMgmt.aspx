<%@ Page Title="" Language="C#" MasterPageFile="~/Consult.Master" AutoEventWireup="true" CodeBehind="AdminLawyerMgmt.aspx.cs" Inherits="ConsultMeTest.AdminLawyerMgmt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Datatable/CSS/jquery.dataTables.min.css" rel="stylesheet" />
    <script src="Datatable/Js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            //$('.table1').DataTable();
        });
    </script>
    <style>
        .larger-text {
            font-family: sans-serif;
            font-size: 24px;
            font-weight: bold;
            display: block;
            color: #001431;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <br />
                <div class="card">

                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="larger-text">Lawyer Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-5">
                                <label>Lawyer ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="Ad_lawyerid" runat="server" placeholder="Lawyer ID"></asp:TextBox>
                                        <asp:LinkButton class="btn btn-primary" ID="go" runat="server" OnClick="go_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-7">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="Ad_fullname" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">

                            <div class="col-md-5">
                                <label>License Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="Ad_number" runat="server" placeholder="License No." ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-7">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="Ad_email" runat="server" placeholder="Email ID" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Username</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="Ad_username" runat="server" placeholder="Username" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Lawyer Status</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control mr-1" ID="status" runat="server" placeholder="Status" ReadOnly="True"></asp:TextBox>
                                        <asp:LinkButton class="btn btn-success mr-1" ID="Verified" runat="server" OnClick="Verified_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                        <asp:LinkButton class="btn btn-warning mr-1" ID="Pending" runat="server" OnClick="Pending_Click"><i class="far fa-pause-circle"></i></asp:LinkButton>
                                        <asp:LinkButton class="btn btn-danger mr-1" ID="Delete" runat="server" OnClick="Delete_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />

                        <center>
                            <br />
                            <a href="Homepage.aspx"><< Back to Home</a><br>
                        </center>
                    </div>
                </div>

                <br>
            </div>
            <div class="col-md-7">
                <br />
                <div class="card">

                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4 class="larger-text">Lawyer List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dinalConnectionString2 %>" ProviderName="<%$ ConnectionStrings:dinalConnectionString2.ProviderName %>" SelectCommand="SELECT [LawyerFullname], [LawyerLicenseNumber], [LawyerUsername], [LawyerStatus], [LawyerID] FROM [Lawyer]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="LawyerList" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="LawyerID">
                                    <Columns>
                                        <asp:BoundField DataField="LawyerID" HeaderText="ID" SortExpression="LawyerID"></asp:BoundField>
                                        <asp:BoundField DataField="LawyerFullname" HeaderText="Fullname" SortExpression="LawyerFullname"></asp:BoundField>
                                        <asp:BoundField DataField="LawyerLicenseNumber" HeaderText="License Number" SortExpression="LawyerLicenseNumber"></asp:BoundField>
                                        <asp:BoundField DataField="LawyerUsername" HeaderText="Username" SortExpression="LawyerUsername"></asp:BoundField>
                                        <asp:BoundField DataField="LawyerStatus" HeaderText="Status" SortExpression="LawyerStatus"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>





</asp:Content>
