<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Pizzaria._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Pizzaria!
    </h2>
    <div>
        <!--<asp:Button ID="btIncluir" runat="server" Text="Inclui com AJAX" />-->
        <input id="btIncluir" type="button" value="Incluir com AJAX" />
    </div>
    <div id="divResultado"></div>
    <script src="Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#btIncluir").click(function () {

            var dados = {};

            var request = $.ajax({
                type: "POST",
                url: "Default.aspx?insertNewPizza=1",
                data: dados
            });

            request.done(function (data) {
                $("#divResultado").html(data);
            });

            request.fail(function (jqXHR, textStatus) {
                alert("Request failed: " + textStatus);
            });
        });
    </script>
</asp:Content>
