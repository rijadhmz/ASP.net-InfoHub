<%@ Page Title="Postavke" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Settings.aspx.cs" Inherits="Settings" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
	<div class="dropdown me-2">
        <button class="btn-lg mx-5 text-primary btn-warning dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
            <asp:PlaceHolder ID="username" runat="server"></asp:PlaceHolder>
        </button>
        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
            <li>
                <asp:PlaceHolder ID ="admin" runat="server">
                </asp:PlaceHolder>
            </li>
            <li><asp:LinkButton ID="btnSettings" class="dropdown-item" runat="server" OnClick="btnSettings_Click">Postavke</asp:LinkButton></li>
            <li><asp:LinkButton ID="btnLogout" class="dropdown-item" runat="server" OnClick="btnLogout_Click">Odjavi se</asp:LinkButton></li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="container-md bg-primary border border-5 border-dark rounded-3 mt-5 text-light" id="loginCont">
        <div class="h4 text-light mt-2">
                Promijeni password
        </div><br />
        <p>Stari password:&nbsp;&nbsp;
        <asp:Label ID="lblStara" class="fs-6 text-danger" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="txtStara" runat="server" type="password" class="form-control" aria-describedby="Stara lozinka"></asp:TextBox>
        </p>
        <br />
        <p>Novi password:<asp:TextBox ID="txtNova" runat="server" type="password" class="form-control" aria-describedby="Nova lozinka"></asp:TextBox></p>
        <br />
        <p>Ponovi novi password:&nbsp;&nbsp;
        <asp:Label ID="lblPonovo" class="fs-6 text-danger" runat="server" Text=""></asp:Label>
        <asp:TextBox ID="txtPonovo" runat="server" type="password" class="form-control" aria-describedby="Nova lozinka"></asp:TextBox></p>
        <br />
        <div class="text-center">
            <asp:Button ID="btnPotvrda" class="btn btn-warning mb-3" runat="server" Text="Potvrdi" OnClick="btnPotvrda_Click" />
        </div>
    </div>
</asp:Content>