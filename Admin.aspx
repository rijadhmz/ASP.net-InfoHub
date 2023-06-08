<%@ Page Title="Admin Opcije" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
	<div class="dropdown me-2">
        <button class="btn-lg mx-5 text-primary btn-warning dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
            <asp:PlaceHolder ID="username" runat="server"></asp:PlaceHolder>
        </button>
        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
            <li><asp:LinkButton ID="btnSettings" class="dropdown-item" runat="server" OnClick="btnSettings_Click">Postavke</asp:LinkButton></li>
            <li><asp:LinkButton ID="btnLogout" class="dropdown-item" runat="server" OnClick="btnLogout_Click">Odjavi se</asp:LinkButton></li>
        </ul>
    </div>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-md px-5 bg-primary border border-5 border-dark rounded-3 mt-5 text-light" id="loginCont">
        <div class="h4 text-light mt-2 text-center">
                Registruj novog korisnika
        </div><br />
        <p>Ime:&nbsp;&nbsp;
        <asp:TextBox ID="txtIme" runat="server" class="form-control" aria-describedby="Ime"></asp:TextBox>
        </p>
        <p>Prezime:<asp:TextBox ID="txtPrezime" runat="server" class="form-control" aria-describedby="Prezime"></asp:TextBox></p>
        <p>Email:&nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server" class="form-control" aria-describedby="Email"></asp:TextBox></p>
        <p>Password:&nbsp;&nbsp;
        <asp:TextBox ID="txtPass" runat="server" class="form-control" type="password" aria-describedby="Password"></asp:TextBox></p>
        <p>Ponovi password:&nbsp;&nbsp;
        <asp:TextBox ID="txtRepeat" runat="server" class="form-control" type="password" aria-describedby="Password"></asp:TextBox></p>
        <asp:CheckBox ID="chkAdmin" runat="server" Text="&nbsp;Adminska prava" />
        <br />
        <br />
        <div class="text-center">
            <asp:Button ID="btnPotvrda" class="btn btn-warning mb-3" runat="server" Text="Potvrdi" OnClick="btnPotvrda_Click" />
        </div>
        <asp:Label ID="lblFail" class="fs-6 text-danger" runat="server" Text=""></asp:Label>
    </div>
    <div class="container-md px-5 py-5 bg-white border border-5 border-primary rounded-3 mt-5 mb-5" id="loginCont">
        <div class="h4 text-primary mt-2 text-center">
                Brisanje objave
        </div><br />
        <p>Objava ID:&nbsp;&nbsp;
            <asp:TextBox ID="txtDelete" runat="server" class="form-control" aria-describedby="Delete"></asp:TextBox>
        </p><br />
        <div class="text-center">
            <asp:Button ID="btnDelete" class="btn btn-danger mb-3" runat="server" Text="Izbrisi" OnClick="btnDelete_Click" />
        </div>
        <asp:Label ID="lblDelete" class="fs-6 text-danger" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>