using System;
using baseLevel1.models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Translation.V2;
using System.Net;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System.Net.Http;
using System.IO;

namespace baseLevel1
{
    public class Translator
    {
        public MethodResult translateText(string text, string ln1, string ln2)
        {
            MethodResult mr = new MethodResult();
            try
            {
                
                MethodResult checkResult = checkText(text, ln1);

                MethodResult translateResult = translate(text,ln1, ln2);





            }
            catch (Exception ex)
            {

            }
            
            return mr;
        }



        public MethodResult checkText(string text, string fromText)
        {
            MethodResult mr = new MethodResult();
            try
            {
                string addr = "https://google-translate1.p.rapidapi.com/language/translate/v2/detect";
                text = "q=" + text;
                string response = SendRequest(text, addr);

                
                mr.text = response;
                mr.message = "success";
                mr.code = 0;
            }
            catch (Exception ex)
            {
                mr.text = null;
                mr.message = ex.Message;
                mr.code = -1;
            }
            return mr;
        }

        public MethodResult translate(string text, string fromText, string toText)
        {
            MethodResult mr = new MethodResult();

            string addr = "https://google-translate1.p.rapidapi.com/language/translate/v2";
            var content = "q=" + text + "&target=" + fromText + "&source=" + toText;
            return mr;
        }

        private string SendRequest(string body, string addr)
        {
            string descript = "";
            string status = "info";
            string resp = "";
            try
            {

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                addr = addr.Trim('/').Trim('\\'); // в конце адреса удалить слэш, если он имеется
                ServicePointManager.ServerCertificateValidationCallback = ((senderr, certificate, chain, sslPolicyErrors) => true);
                WebRequest _request = HttpWebRequest.Create(addr);

                //метод POST/GET и.т.д
                _request.Method = "POST";
                _request.ContentType = "application/x-www-form-urlencoded";
                //_request.ContentLength = body.Length;

                //добавляю загаловки сервиса

                _request.Headers.Add("Accept-Encoding", "application/gzip");
                _request.Headers.Add("X-RapidAPI-Host", "google-translate1.p.rapidapi.com");
                _request.Headers.Add("X-RapidAPI-Key", "bc51031004msh29d9f02bc00f99ap1135e5jsn085f0bdf3749");


                // пишу тело
                StreamWriter _streamWriter = new StreamWriter(_request.GetRequestStream());
                _streamWriter.Write(body);
                _streamWriter.Close();
                // читаем тело
                WebResponse _response = _request.GetResponse();

                StreamReader _streamReader = new StreamReader(_response.GetResponseStream());
                resp = _streamReader.ReadToEnd();

            }
            catch (Exception ex)
            {
                throw new Exception("Не удалось выполнить запрос к API переводчика, ошибка: " + ex.Message);
            }
           
            return resp;
        }


    }
}
