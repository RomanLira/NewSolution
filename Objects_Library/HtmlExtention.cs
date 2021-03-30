using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Objects_Library
{
    public static class HtmlExtention
    {
        public static void HtmlDoc(this Person p)
        {
            var dataDirectory = Directory.GetCurrentDirectory();
            var htmlCode = @"<!DOCTYPE html>
<html>
<head>
	<style>
	table {
		font-family: montserrat;
		border-collapse: collapse;
		margin: auto;     
		}
	td, th {
		border: 1px solid black;
		text-align: center;
		padding: 2px;
		}
	</style>
</head>
<body>
<table>
	<caption><b>Person Info</b></caption>
	<tr>
	<th>FullName</th>
	<td>" + p.FullName + @"</td>
	</tr>
	<tr>
	<th>BirthDay</th>
	<td>" + p.BirthDay + @"</td>
	</tr>
	<tr>
	<th>BirthPlace</th>
	<td>" + p.BirthPlace + @"</td>
	</tr>
	<tr>
	<th>Passport ID</th>
	<td>" + p.ID + @"</td>
	</tr>
</table>
</body>
</html>";
            using (FileStream fileStream = File.Open(dataDirectory + @"/" + p.FullName + ".html",
                FileMode.OpenOrCreate))
            {
                byte[] code = Encoding.Default.GetBytes(htmlCode);
                fileStream.Write(code, 0, code.Length);
            }
        }
    }
}
