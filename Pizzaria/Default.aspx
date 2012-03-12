<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Pizzaria._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Pizzaria!
    </h2>
    <p>
    <b>Nome da Pizza:</b>
        <br/><input id="txtNome" type="text" />
    </p>
    <p>Ingredientes:</p>
    <p><asp:TextBox ID="txtIngrediente1" runat="server"></asp:TextBox></p>
    <p><asp:TextBox ID="txtIngrediente2" runat="server"></asp:TextBox></p>    
    <p><asp:TextBox ID="txtIngrediente3" runat="server"></asp:TextBox></p>
    <div>
        <!--<asp:Button ID="btIncluir" runat="server" Text="Inclui com AJAX" />-->
        <input id="btIncluir" type="button" value="Incluir com AJAX" />
    </div>
    <div id="divResultado"></div>
    <script src="Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#btIncluir").click(function () {
            
            var dados = "Nome=" + $("#txtNome").val()
            + "&I1=" + $("#MainContent_txtIngrediente1").val()
            + "&I2=" + $("#MainContent_txtIngrediente2").val()
            + "&I3=" + $("#MainContent_txtIngrediente3").val();
            
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
