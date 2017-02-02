<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="SmartShow_Client.UploadFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>File Upload Portal</title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->

    <style type="text/css">
        .auto-style1 {
            width: 241px;
        }

        .auto-style2 {
            width: 397px;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="jumbotron" style="align-content: center; box-shadow: 0px 2px 5px #ccc; border: 1px solid #888; align-items: center; align-self: center; color-rendering: optimizeQuality; color: black; font-family: 'Times New Roman', Times, serif">
                <h1>Upload Files</h1>

            </div>
            <div class="col-md-3"></div>
            <div class="col-md-3">
                <table class="table-hover table-responsive tab-pane" style="align-content: center; align-self: center; box-shadow: 1px 2px 5px #ccc; border: 1px solid #888;">
                    <tr>
                        <td style="align-content: center; padding: 10px 10px 10px 10px">
                            <label class="control-label">Select File</label>
                            <asp:FileUpload ID="fuUploadFile" runat="server" OnDataBinding="fuUploadFile_DataBinding"/>
                        </td>
                        <td style="align-content: center; padding: 10px 10px 10px 10px">
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload" CssClass="btn-lg" />
                        </td>
                    </tr>



                </table>


                <br />
                <div id="alertError" class="alert alert-danger collapse">
                    <a href="#" id="lnkErrorClose" class="close" data-dismiss="alert">&times;</a>
                    <strong>Error!</strong> There was a problem while uploading the file
                </div>
                <div id="alertSuccess" class="alert alert-success collapse">
                    <a href="#" id="lnkSuccessClose" class="close" data-dismiss="alert">&times;</a>
                    <strong>Success</strong> File uploaded successfully
                </div>

            </div>
            <div class="col-md-3"></div>
        </div>


        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <%--<script type="text/javascript">
            $(document).ready(function () {
                $("#Button1").click(function () {
                    $("#alertError").show('fade');
                  $("#alertSuccess").show('fade');

                    setTimeout(function () {
                        $("#alertError").hide('fade')
                    }, 2000);

                    setTimeout(function () {
                        $("#alertSuccess").hide('fade')
                    }, 2000);

                });


                $("#lnkErrorClose").click(function () {
                    $("#alertError").hide('fade');
                });


                $("#lnkSuccessClose").click(function () {
                    $("#alertSuccess").hide('fade');
                });

            });
        </script>--%>

    </form>

</body>
</html>
