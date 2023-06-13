using System;

using System.Net;

using System.Net.Mail;

using System.Threading.Tasks;

public class EmailLogic

{
    static JsonAccessor<ShoppingCartModel> _shoppingCartAccesor = new JsonAccessor<ShoppingCartModel>(@"DataSources/shoppingcart.json");
    public static List<ShoppingCartModel>? shoppingCart;
    public static List<string> shopping_cart_list = new List<string>();
    public static List<string> seats_list = new List<string>();
    string shopping_cart = string.Join(", ", shopping_cart_list);
    string seats = string.Join(",", seats_list);




    public void SendReservationEmail(string mail, string movie, string seat, DateTime startTime, double Totalprice, int randomcode)
    {
        string fromMail = "info.hetbioscoopje@gmail.com";

        string fromPassword = "xiqngqxgmictafgk";

        MailMessage message = new MailMessage();

        message.From = new MailAddress(fromMail);

        message.Subject = "Reservatie";

        message.To.Add(new MailAddress($"{mail}"));

        string htmlBody = "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">\n";

        htmlBody += "<html>\n";

        htmlBody += "\n";

        htmlBody += "<head>\n";

        htmlBody += "<!-- Compiled with Bootstrap Email version: 1.3.1 -->\n";

        htmlBody += "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\n";

        htmlBody += "<meta http-equiv=\"x-ua-compatible\" content=\"ie=edge\">\n";

        htmlBody += "<meta name=\"x-apple-disable-message-reformatting\">\n";

        htmlBody += "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\n";

        htmlBody += "<meta name=\"format-detection\" content=\"telephone=no, date=no, address=no, email=no\">\n";

        htmlBody += "<link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">\n";

        htmlBody += "<link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin>\n";

        htmlBody += "<link href=\"https://fonts.googleapis.com/css2?family=Poppins&display=swap\" rel=\"stylesheet\">\n";

        htmlBody += "<style type=\"text/css\">\n";

        htmlBody += "* { font-family: 'Poppins', sans-serif !important; }";

        htmlBody += "body,\n";

        htmlBody += "table,\n";

        htmlBody += "td {\n";

        htmlBody += "font-family: Helvetica, Arial, sans-serif\n";

        htmlBody += "}\n";

        htmlBody += "\n";

        htmlBody += ".ExternalClass {\n";

        htmlBody += "width: 100%\n";

        htmlBody += "}\n";

        htmlBody += "\n";

        htmlBody += ".ExternalClass,\n";

        htmlBody += ".ExternalClass p,\n";

        htmlBody += ".ExternalClass span,\n";

        htmlBody += ".ExternalClass font,\n";

        htmlBody += ".ExternalClass td,\n";

        htmlBody += ".ExternalClass div {\n";

        htmlBody += "line-height: 150%\n";

        htmlBody += "}\n";

        htmlBody += "\n";

        htmlBody += "a {\n";

        htmlBody += "text-decoration: none\n";

        htmlBody += "}\n";

        htmlBody += "\n";

        htmlBody += "* {\n";

        htmlBody += "color: inherit\n";

        htmlBody += "}\n";

        htmlBody += "\n";

        htmlBody += "a[x-apple-data-detectors],\n";

        htmlBody += "u+#body a,\n";

        htmlBody += "#MessageViewBody a {\n";

        htmlBody += "color: inherit;\n";

        htmlBody += "text-decoration: none;\n";

        htmlBody += "font-size: inherit;\n";

        htmlBody += "font-family: inherit;\n";

        htmlBody += "font-weight: inherit;\n";

        htmlBody += "line-height: inherit\n";

        htmlBody += "}\n";

        htmlBody += "\n";

        htmlBody += "img {\n";

        htmlBody += "-ms-interpolation-mode: bicubic\n";

        htmlBody += "}\n";

        htmlBody += "\n";

        htmlBody += "table:not([class^=s-]) {\n";

        htmlBody += "font-family: Helvetica, Arial, sans-serif;\n";

        htmlBody += "            mso-table-lspace: 0pt;\n";

        htmlBody += "            mso-table-rspace: 0pt;\n";

        htmlBody += "            border-spacing: 0px;\n";

        htmlBody += "            border-collapse: collapse\n";

        htmlBody += "        }\n";

        htmlBody += "\n";

        htmlBody += "        table:not([class^=s-]) td {\n";

        htmlBody += "            border-spacing: 0px;\n";

        htmlBody += "            border-collapse: collapse\n";

        htmlBody += "        }\n";

        htmlBody += "\n";

        htmlBody += "        @media screen and (max-width: 600px) {\n";

        htmlBody += "\n";

        htmlBody += "            .w-lg-48,\n";

        htmlBody += "            .w-lg-48>tbody>tr>td {\n";

        htmlBody += "                width: auto !important\n";

        htmlBody += "            }\n";

        htmlBody += "\n";

        htmlBody += "            .w-full,\n";

        htmlBody += "            .w-full>tbody>tr>td {\n";

        htmlBody += "                width: 100% !important\n";

        htmlBody += "            }\n";

        htmlBody += "\n";

        htmlBody += "            .w-16,\n";

        htmlBody += "            .w-16>tbody>tr>td {\n";

        htmlBody += "                width: 64px !important\n";

        htmlBody += "            }\n";

        htmlBody += "\n";

        htmlBody += "            .p-lg-10:not(table),\n";

        htmlBody += "            .p-lg-10:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .p-lg-10.btn td a {\n";

        htmlBody += "                padding: 0 !important\n";

        htmlBody += "            }\n";

        htmlBody += "\n";

        htmlBody += "            .p-2:not(table),\n";

        htmlBody += "            .p-2:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .p-2.btn td a {\n";

        htmlBody += "                padding: 8px !important\n";

        htmlBody += "            }\n";

        htmlBody += "\n";

        htmlBody += "            .pr-4:not(table),\n";

        htmlBody += "            .pr-4:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .pr-4.btn td a,\n";

        htmlBody += "            .px-4:not(table),\n";

        htmlBody += "            .px-4:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .px-4.btn td a {\n";

        htmlBody += "                padding-right: 16px !important\n";

        htmlBody += "            }\n";

        htmlBody += "\n";

        htmlBody += "            .pl-4:not(table),\n";

        htmlBody += "            .pl-4:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .pl-4.btn td a,\n";

        htmlBody += "            .px-4:not(table),\n";

        htmlBody += "            .px-4:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .px-4.btn td a {\n";

        htmlBody += "                padding-left: 16px !important\n";

        htmlBody += "            }\n";

        htmlBody += "\n";

        htmlBody += "            .pr-6:not(table),\n";

        htmlBody += "            .pr-6:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .pr-6.btn td a,\n";

        htmlBody += "            .px-6:not(table),\n";

        htmlBody += "            .px-6:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .px-6.btn td a {\n";

        htmlBody += "                padding-right: 24px !important\n";

        htmlBody += "            }\n";

        htmlBody += "\n";

        htmlBody += "            .pl-6:not(table),\n";

        htmlBody += "            .pl-6:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .pl-6.btn td a,\n";

        htmlBody += "            .px-6:not(table),\n";

        htmlBody += "            .px-6:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .px-6.btn td a {\n";

        htmlBody += "                padding-left: 24px !important\n";

        htmlBody += "            }\n";

        htmlBody += "\n";

        htmlBody += "            .pt-8:not(table),\n";

        htmlBody += "            .pt-8:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .pt-8.btn td a,\n";

        htmlBody += "            .py-8:not(table),\n";

        htmlBody += "            .py-8:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .py-8.btn td a {\n";

        htmlBody += "                padding-top: 32px !important\n";

        htmlBody += "            }\n";

        htmlBody += "\n";

        htmlBody += "            .pb-8:not(table),\n";

        htmlBody += "            .pb-8:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .pb-8.btn td a,\n";

        htmlBody += "            .py-8:not(table),\n";

        htmlBody += "            .py-8:not(.btn)>tbody>tr>td,\n";

        htmlBody += "            .py-8.btn td a {\n";

        htmlBody += "                padding-bottom: 32px !important\n";

        htmlBody += "            }\n";

        htmlBody += "\n";

        htmlBody += "            *[class*=s-lg-]>tbody>tr>td {\n";

        htmlBody += "                font-size: 0 !important;\n";

        htmlBody += "                line-height: 0 !important;\n";

        htmlBody += "                height: 0 !important\n";

        htmlBody += "            }\n";

        htmlBody += "\n";

        htmlBody += "            .s-4>tbody>tr>td {\n";

        htmlBody += "                font-size: 16px !important;\n";

        htmlBody += "                line-height: 16px !important;\n";

        htmlBody += "                height: 16px !important\n";

        htmlBody += "            }\n";

        htmlBody += "\n";

        htmlBody += "            .s-6>tbody>tr>td {\n";

        htmlBody += "                font-size: 24px !important;\n";

        htmlBody += "                line-height: 24px !important;\n";

        htmlBody += "                height: 24px !important\n";

        htmlBody += "            }\n";

        htmlBody += "        }\n";

        htmlBody += "    </style>\n";

        htmlBody += "</head>\n";

        htmlBody += "\n";

        htmlBody += "<body class=\"bg-red-100\"\n";

        htmlBody += "style=\"outline: 0; width: 100%; min-width: 100%; height: 100%; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; font-family: 'Poppins', sans-serif !important; line-height: 24px; font-weight: normal; font-size: 16px; -moz-box-sizing: border-box; -webkit-box-sizing: border-box; box-sizing: border-box; color: #000000; margin: 0; padding: 0; border-width: 0;\"\n";

        htmlBody += "bgcolor=\"#f8d7da\">\n";

        htmlBody += "<table class=\"bg-red-100 body\" valign=\"top\" role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"\n";

        htmlBody += "        style=\"outline: 0; width: 100%; min-width: 100%; height: 100%; -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; font-family: 'Poppins', sans-serif !important; line-height: 24px; font-weight: normal; font-size: 16px; -moz-box-sizing: border-box; -webkit-box-sizing: border-box; box-sizing: border-box; color: #000000; margin: 0; padding: 0; border-width: 0;\"\n";

        htmlBody += "        bgcolor=\"#f8d7da\">\n";

        htmlBody += "        <tbody>\n";

        htmlBody += "            <tr>\n";

        htmlBody += "                <td valign=\"top\" style=\"line-height: 24px; font-size: 16px; margin: 0;\" align=\"left\" bgcolor=\"#f8d7da\">\n";

        htmlBody += "                    <table class=\"container\" role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"\n";

        htmlBody += "                        style=\"width: 100%;\">\n";

        htmlBody += "                        <tbody>\n";

        htmlBody += "                            <tr>\n";

        htmlBody += "                                <td align=\"center\"\n";

        htmlBody += "                                    style=\"line-height: 24px; font-size: 16px; margin: 0; padding: 0 16px;\">\n";

        htmlBody += "                                    <table align=\"center\" role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"\n";

        htmlBody += "                                        style=\"width: 100%; max-width: 600px; margin: 0 auto;\">\n";

        htmlBody += "                                        <tbody>\n";

        htmlBody += "                                            <tr>\n";

        htmlBody += "                                                <td style=\"line-height: 24px; font-size: 16px; margin: 0;\" align=\"left\">\n";

        htmlBody += "                                                    <table class=\"s-6 w-full\" role=\"presentation\" border=\"0\"\n";

        htmlBody += "                                                        cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%;\"\n";

        htmlBody += "                                                        width=\"100%\">\n";

        htmlBody += "                                                        <tbody>\n";

        htmlBody += "                                                            <tr>\n";

        htmlBody += "                                                                <td style=\"line-height: 24px; font-size: 24px; width: 100%; height: 24px; margin: 0;\"\n";

        htmlBody += "                                                                    align=\"left\" width=\"100%\" height=\"24\">\n";

        htmlBody += "                                                                    &#160;\n";

        htmlBody += "                                                                </td>\n";

        htmlBody += "                                                            </tr>\n";

        htmlBody += "                                                        </tbody>\n";

        htmlBody += "                                                    </table>\n";

        htmlBody += "                                                    <table class=\"s-6 w-full\" role=\"presentation\" border=\"0\"\n";

        htmlBody += "                                                        cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%;\"\n";

        htmlBody += "                                                        width=\"100%\">\n";

        htmlBody += "                                                        <tbody>\n";

        htmlBody += "                                                            <tr>\n";

        htmlBody += "                                                                <td style=\"line-height: 24px; font-size: 24px; width: 100%; height: 24px; margin: 0;\"\n";

        htmlBody += "                                                                    align=\"left\" width=\"100%\" height=\"24\">\n";

        htmlBody += "                                                                    &#160;\n";

        htmlBody += "                                                                </td>\n";

        htmlBody += "                                                            </tr>\n";

        htmlBody += "                                                        </tbody>\n";

        htmlBody += "                                                    </table>\n";

        htmlBody += "                                                    <div class=\"space-y-4\">\n";

        htmlBody += "                                                        <h1 class=\"text-4xl fw-800\"\n";

        htmlBody += "                                                            style=\"padding-top: 0; padding-bottom: 0; font-weight: 800 !important; vertical-align: baseline; font-size: 36px; line-height: 43.2px; margin: 0;\"\n";

        htmlBody += "                                                            align=\"left\">Bedankt voor het reserveren,\n";

        htmlBody += "                                                        </h1>\n";

        htmlBody += "                                                        <table class=\"s-4 w-full\" role=\"presentation\" border=\"0\"\n";

        htmlBody += "                                                            cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%;\"\n";

        htmlBody += "                                                            width=\"100%\">\n";

        htmlBody += "                                                            <tbody>\n";

        htmlBody += "                                                                <tr>\n";

        htmlBody += "                                                                    <td style=\"line-height: 16px; font-size: 16px; width: 100%; height: 16px; margin: 0;\"\n";

        htmlBody += "                                                                        align=\"left\" width=\"100%\" height=\"16\">\n";

        htmlBody += "                                                                        &#160;\n";

        htmlBody += "                                                                    </td>\n";

        htmlBody += "                                                                </tr>\n";

        htmlBody += "                                                            </tbody>\n";

        htmlBody += "                                                        </table>\n";

        htmlBody += "                                                        <p class=\"\"\n";

        htmlBody += "                                                            style=\"line-height: 24px; font-size: 16px; width: 100%; margin: 0;\"\n";

        htmlBody += $"                                                            align=\"center\">Bedankt {mail} dat u heeft gereserveerd bij Het Bioscoopje\n";

        htmlBody += "                                                        </p>\n";

        htmlBody += "                                                        <table class=\"s-4 w-full\" role=\"presentation\" border=\"0\"\n";

        htmlBody += "                                                            cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%;\"\n";

        htmlBody += "                                                            width=\"100%\">\n";

        htmlBody += "                                                            <tbody>\n";

        htmlBody += "                                                                <tr>\n";

        htmlBody += "                                                                    <td style=\"line-height: 16px; font-size: 16px; width: 100%; height: 16px; margin: 0;\"\n";

        htmlBody += "                                                                        align=\"left\" width=\"100%\" height=\"16\">\n";

        htmlBody += "                                                                        &#160;\n";

        htmlBody += "                                                                    </td>\n";

        htmlBody += "                                                                </tr>\n";

        htmlBody += "                                                            </tbody>\n";

        htmlBody += "                                                        </table>\n";

        htmlBody += "                                                        <table class=\"btn btn-red-500 rounded-full px-6 w-full w-lg-48\"\n";

        htmlBody += "                                                            role=\"presentation\" border=\"0\" cellpadding=\"0\"\n";

        htmlBody += "                                                            cellspacing=\"0\"\n";

        htmlBody += "                                                            style=\"border-radius: 9999px; border-collapse: separate !important; width: 192px;\"\n";

        htmlBody += "                                                            width=\"192\">\n";

        htmlBody += "                                                        </table>\n";

        htmlBody += "                                                    </div>\n";

        htmlBody += "                                                    <table class=\"s-6 w-full\" role=\"presentation\" border=\"0\"\n";

        htmlBody += "                                                        cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%;\"\n";

        htmlBody += "                                                        width=\"100%\">\n";

        htmlBody += "                                                        <tbody>\n";

        htmlBody += "                                                            <tr>\n";

        htmlBody += "                                                                <td style=\"line-height: 24px; font-size: 24px; width: 100%; height: 24px; margin: 0;\"\n";

        htmlBody += "                                                                    align=\"left\" width=\"100%\" height=\"24\">\n";

        htmlBody += "                                                                    &#160;\n";

        htmlBody += "                                                                </td>\n";

        htmlBody += "                                                            </tr>\n";

        htmlBody += "                                                        </tbody>\n";

        htmlBody += "                                                    </table>\n";

        htmlBody += "                                                    <table class=\"card rounded-3xl px-4 py-8 p-lg-10\"\n";

        htmlBody += "                                                        role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"\n";

        htmlBody += "                                                        style=\"border-radius: 24px; border-collapse: separate !important; width: 100%; overflow: hidden; border: 1px solid #e2e8f0;\"\n";

        htmlBody += "                                                        bgcolor=\"#ffffff\">\n";

        htmlBody += "                                                        <tbody>\n";

        htmlBody += "                                                            <tr>\n";

        htmlBody += "                                                                <td style=\"line-height: 24px; font-size: 16px; width: 100%; border-radius: 24px; margin: 0; padding: 40px;\"\n";

        htmlBody += "                                                                    align=\"left\" bgcolor=\"#ffffff\">\n";

        htmlBody += $"                                                                    <img src=\"https://man-man.nl/app/uploads/2019/12/luxe-bioscopen-in-nederland.jpg\" title =\"Bioscoopzaal\" alt=\"Bioscoop\" style=\"width: 100%;\">\n";

        htmlBody += "                                                                    <h3 class=\"text-center\"\n";

        htmlBody += "                                                                        style=\"padding-top: 0; padding-bottom: 20px; font-weight: 500; vertical-align: baseline; font-size: 28px; line-height: 33.6px; margin: 0;\"\n";

        htmlBody +=
            "                                                                        align=\"center\">Uw Reservering:</h3>\n";
        htmlBody += $"                                                                <h3 align=\"center\">Tickets voor {movie}:</h3>\n";
        htmlBody += "                                                                <h3 align=\"center\">-------------</h3>\n";
        htmlBody += $"                                                                <h3 align=\"center\">Seats: {seats},</h3>\n";
        htmlBody += $"                                                                <h3 align=\"center\">Start Time: {startTime},</h3>\n";
        htmlBody += "                                                                <h3 align=\"center\">-------------</h3>\n";
        htmlBody += $"                                                                <h3 align=\"center\">Shopping cart items: {shopping_cart}</h3>\n";
        htmlBody += $"                                                                <h3 align=\"center\">Total price: {Totalprice}</h3>\n";
        htmlBody += "                                                                <h3 align=\"center\">-------------</h3>\n";
        htmlBody += $"                                                                <h3 align=\"center\">Reservation Code: {randomcode}</h3>\n";



        htmlBody += "                                                                    <h1 class=\"text-4xl fw-800\"\n";

        htmlBody += "                                                                        style=\" padding-bottom: 0; font-weight: 600 !important; vertical-align: baseline; font-size: 3rem; line-height: 43.2px; margin: 0 auto;  letter-spacing: 5px;\"\n";

        htmlBody += "                                                                        <!-- via c# naam meesturen -->\n";

        htmlBody += "                                                                    </h1>\n";

        htmlBody += "                                                                    <p class=\"text-center\"\n";

        htmlBody += "                                                                        style=\"padding-top: 50px; color: darkgray; padding-bottom: 20px; font-weight: 400; vertical-align: baseline; font-size: 16px; line-height: 33.6px; margin: 0;\"\n";

        htmlBody += "                                                                    <table class=\"s-6 w-full\" role=\"presentation\"\n";

        htmlBody += "                                                                        border=\"0\" cellpadding=\"0\" cellspacing=\"0\"\n";

        htmlBody += "                                                                        style=\"width: 100%;\" width=\"100%\">\n";

        htmlBody += "                                                                        <tbody>\n";

        htmlBody += "                                                                            <tr>\n";

        htmlBody += "                                                                                <td style=\"line-height: 24px; font-size: 24px; width: 100%; height: 24px; margin: 0;\"\n";

        htmlBody += "                                                                                    align=\"left\" width=\"100%\"\n";

        htmlBody += "                                                                                    height=\"24\">\n";

        htmlBody += "                                                                                    &#160;\n";

        htmlBody += "                                                                                </td>\n";

        htmlBody += "                                                                            </tr>\n";

        htmlBody += "                                                                        </tbody>\n";

        htmlBody += "                                                                    </table>\n";

        htmlBody += "                                                                    <table class=\"hr\" role=\"presentation\" border=\"0\"\n";

        htmlBody += "                                                                        cellpadding=\"0\" cellspacing=\"0\"\n";

        htmlBody += "                                                                        style=\"width: 100%;\">\n";

        htmlBody += "                                                                        <tbody>\n";

        htmlBody += "                                                                            <tr>\n";

        htmlBody += "                                                                                <td style=\"line-height: 24px; font-size: 16px; border-top-width: 1px; border-top-color: #e2e8f0; border-top-style: solid; height: 1px; width: 100%; margin: 0;\"\n";

        htmlBody += "                                                                                    align=\"left\">\n";

        htmlBody += "                                                                                </td>\n";

        htmlBody += "                                                                            </tr>\n";

        htmlBody += "                                                                        </tbody>\n";

        htmlBody += "                                                                    </table>\n";

        htmlBody += "                                                                    <table class=\"s-6 w-full\" role=\"presentation\"\n";

        htmlBody += "                                                                        border=\"0\" cellpadding=\"0\" cellspacing=\"0\"\n";

        htmlBody += "                                                                        style=\"width: 100%;\" width=\"100%\">\n";

        htmlBody += "                                                                        <tbody>\n";

        htmlBody += "<tr>\n";

        htmlBody += "<td style=\"line-height: 24px; font-size: 24px; width: 100%; height: 24px; margin: 0;\"\n";

        htmlBody += "align=\"left\" width=\"100%\"\n";

        htmlBody += "height=\"24\">\n";

        htmlBody += "&#160;\n";

        htmlBody += "</td>\n";

        htmlBody += "</tr>\n";

        htmlBody += "</tbody>\n";

        htmlBody += "</table>\n";

        htmlBody += "<p style=\"line-height: 24px; font-size: 16px; color:darkgray; width: 100%; margin: 0;\"\n";
        htmlBody += "align=\"left\">Als u vragen heeft kun u ons\n";

        htmlBody += "bellen via: 06-485768857\n";

        htmlBody += "</p>\n";

        htmlBody += "<p style=\"line-height: 24px; font-size: 16px; color:darkgray; color: red; width: 100%; margin: 0;\"\n";

        htmlBody += "align=\"left\">Vergeet niet te laat of niet te komen!\n";

        htmlBody += "Dit kan leiden tot een boete\n";

        htmlBody += "</p>\n";

        htmlBody += "</td>\n";

        htmlBody += "</tr>\n";

        htmlBody += "</tbody>\n";

        htmlBody += "</table>\n";

        htmlBody += "<table class=\"s-6 w-full\" role=\"presentation\" border=\"0\"\n";

        htmlBody += "cellpadding=\"0\" cellspacing=\"0\" style=\"width: 100%;\"\n";

        htmlBody += "width=\"100%\">\n";

        htmlBody += "<tbody>\n";

        htmlBody += "<tr>\n";

        htmlBody += "<td style=\"line-height: 24px; font-size: 24px; width: 100%; height: 24px; margin: 0;\"\n";

        htmlBody += "align=\"left\" width=\"100%\" height=\"24\">\n";

        htmlBody += "&#160;\n";

        htmlBody += "</td>\n";

        htmlBody += "</tr>\n";

        htmlBody += "</tbody>\n";

        htmlBody += "</table>\n";

        htmlBody += "</td>\n";

        htmlBody += "</tr>\n";

        htmlBody += "</tbody>\n";

        htmlBody += "</table>\n";

        htmlBody += "</td>\n";

        htmlBody += "</tr>\n";

        htmlBody += "</tbody>\n";

        htmlBody += "</table>\n";

        htmlBody += "</td>\n";

        htmlBody += "</tr>\n";

        htmlBody += "</tbody>\n";

        htmlBody += "</table>\n";

        htmlBody += "<script data-cfasync=\"false\" src=\"/cdn-cgi/scripts/5c5dd728/cloudflare-static/email-decode.min.js\"></script>\n";

        htmlBody += "</body>\n";

        htmlBody += "\n";

        htmlBody += "</html>\n";




        message.Body = htmlBody;

        message.IsBodyHtml = true;




        var smtpClient = new SmtpClient("smtp.gmail.com")

        {

            Port = 587,

            Credentials = new NetworkCredential(fromMail, fromPassword),

            EnableSsl = true,

        };




        smtpClient.Send(message);

    }
    /*public void SendModifiedMovieEmail()
    {
        var smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential("info.hetbioscoopje@gmail.com", "pqqlwfrqeplyfyll");
        smtpClient.EnableSsl = true; ;

        var MailMessage = new MailMessage
        {
            From = new MailAddress("info.hetbioscoopje@gmail.com"),
            Subject = "Your Reservation has been Modified",
            Body = $"<h1>Dear {UserLogin.User_Name},\n" +
                   "Your reservation has been Modified</h1>" +
                   $"<h2>You now reserved for {ReservationsLogic.new_movie}</h2>",
            IsBodyHtml = true
        };
        MailMessage.To.Add(UserLogin.User_Email);
        smtpClient.Send(MailMessage);*/

}
/*public void SendModifiedSeatEmail()
{
    var smtpClient = new SmtpClient("smtp.gmail.com", 587);
    smtpClient.UseDefaultCredentials = false;
    smtpClient.Credentials = new NetworkCredential("info.hetbioscoopje@gmail.com", "pqqlwfrqeplyfyll");
    smtpClient.EnableSsl = true; ;

    var MailMessage = new MailMessage
    {
        From = new MailAddress("info.hetbioscoopje@gmail.com"),
        Subject = "Your Reservation has been Modified",
        Body = $"<h1>Dear {UserLogin.User_Name},\n" +
               "Your reservation has been Modified</h1>" +
               $"<h2>Your seat has changed to seat {ReservationsLogic.new_seat}</h2>",
        IsBodyHtml = true
    };
    MailMessage.To.Add(UserLogin.User_Email);
    smtpClient.Send(MailMessage);*/

/*public void SendModifiedEmail()
{
    var smtpClient = new SmtpClient("smtp.gmail.com", 587);
    smtpClient.UseDefaultCredentials = false;
    smtpClient.Credentials = new NetworkCredential("info.hetbioscoopje@gmail.com", "pqqlwfrqeplyfyll");
    smtpClient.EnableSsl = true; ;

    var MailMessage = new MailMessage
    {
        From = new MailAddress("info.hetbioscoopje@gmail.com"),
        Subject = "Your Reservation has been Modified",
        Body = $"<h1>Dear {UserLogin.User_Name},\n" +
               "Your reservation has been Modified</h1>" +
               $"<h2>Your email has changed to {ReservationsLogic.new_email}</h2>",
        IsBodyHtml = true
    };
    MailMessage.To.Add(ReservationsLogic.new_email);
    smtpClient.Send(MailMessage);*/


/*public void SendModifiedEmails()
{

}*/