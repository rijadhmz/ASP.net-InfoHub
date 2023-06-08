<%@ Page Title="Prijava OK7" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
	    <div class="container-md mx-auto py-5 px-5 mt-5 border border-dark bg-primary border-5 rounded text-primary" id="loginCont">
            <div class="h1 text-light text-center mt-2">
                <div class="h2 mb-3">Prijavi se</div>
            </div>


        <div class="mb-3">
            <label for="email" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" class="form-control" aria-describedby="emailHelp"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="password" class="form-label">Password</label>
            <asp:TextBox type="password" ID="txtPass" runat="server" class="form-control" aria-describedby="passwordHelp"></asp:TextBox>
        </div>
        <asp:Button ID="btnLogin" class="btn btn-warning mb-5" runat="server" Text="Prijava" OnClick="btnLogin_Click" />

        </div>
    </div>
    </asp:Content>
