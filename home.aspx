<%@ Page Title="Pocetna Stranica" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content2" ContentPlaceholderID="ContentPlaceHolder2" runat="server">
	<div class="dropdown me-2">
        <button class="btn mx-5 btn-warning dropdown-toggle btn-lg text-primary" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
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



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script>
        function resizeTextBox(txt) {
            if (txt.scrollHeight < 300) {
                txt.style.height = "63px";
                txt.style.height = (3 + txt.scrollHeight) + "px";
            }
        }
    </script>
    <div class="container-md" id="homeCont">
        <div class="container-xl px-5 py-2 mt-5 bg-primary border border-5 border-dark rounded-3" id="newPost">
            <div class="h4 text-light mt-2 text-center">
                Nova objava
            </div>
            <div class="text-center">
                <asp:TextBox textmode="MultiLine" ID="txtNew" runat="server" class="form-control" onkeyup="resizeTextBox(this)" ReadOnly="False" placeholder="Klliknite ovdje da pisete..."></asp:TextBox>
                <asp:Button ID="btnNew" runat="server" Text="Objavi" type="submit" class="btn btn-warning mb-3 mt-3" OnClick="btnNew_Click" />
            </div>
        </div>
        <div id="postovi" class="container-md bg-white border border-5 border-primary rounded-3 mt-5 mb-5" runat="server"><div class="h4 text-primary mt-2 text-center mt-3 mb-5">Info Hub</div>
            <div id = "maindiv">
                <asp:PlaceHolder ID ="maindivs" runat="server">
                </asp:PlaceHolder>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

</asp:Content>