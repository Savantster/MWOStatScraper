/*
 *   MWOStatScraper is a tool to gather and process personal match data from 
 *   the MWOMercs website, for the game MechWarrior Online.
 * 
 *   Copyright (C) 2014  {Ray}
 *   
 *   See the full license notification in the frmMWOStatSys.cs file
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentStreaming.SharpTools
{
    // I (Ray) pulled this off the web, this is not my code.. all credits and copyrights belong to the original
    // author, and I thank her for allowing free usage of these classes as they saved me a lot of headache.
    //
    // Here is the link to Katy's blogsite where I got the code..
    // http://katyscode.wordpress.com/2008/01/26/sharptools-http-get-post-uploading-files-and-cookiesession-authentication-in-c/

    /// <summary>
    /// HTTP Method: GET, POST, or POST with files/attachments
    /// </summary>
    public enum HTTPRequestType { Get, Post, MultipartPost }

    /// <summary>
    /// HTTP Helper Class
    /// </summary>
    public class HTTPWorker
    {
        private HttpWebRequest req;
        private HttpWebResponse rsp;
        private string rspText;
        private MIMEPayload mimePayload;
        private CookieCollection cookies;
        private bool persistCookies;
        private string postVars;

        /// <summary>
        /// The URL of the next request. This must be set before any other parameters.
        /// </summary>
        public string Url
        {
            get
            {
                if ( req == null )
                    return null;

                return req.RequestUri.OriginalString;
            }
            set
            {
                // added by me(Ray).. seems we hang with the new way I'm using it, something about
                // running out of resources if we're not clearing out the request object, so
                // instead of just getting a new one and leaving the old one out there, we
                // explicity close it before we move on to a new, clean set of objects..
                if ( req != null )
                {
                    req.GetResponse().Close();
                }

                req = (HttpWebRequest)WebRequest.Create( value );

                // This is to prevent the "417" status code error from web servers
                // that don't support sending POST data in a follow-up request
                req.ServicePoint.Expect100Continue = false;

                // Don't allow 302 auto-redirects by default
                req.AllowAutoRedirect = false;
                //ServicePointManager.DefaultConnectionLimit = 10;
            }
        }

        /// <summary>
        /// Set the request type. This must be set before any arguments are added
        /// to the request, but after the URL is set.
        /// </summary>
        public HTTPRequestType Type
        {
            set
            {
                if ( req == null )
                    throw new WebException( "Set the URI first." );

                switch ( value )
                {
                    // GET request
                    case HTTPRequestType.Get:
                        mimePayload = null;
                        postVars = null;
                        req.Method = "GET";
                        break;

                    // POST request
                    case HTTPRequestType.Post:
                        mimePayload = null;
                        postVars = "";
                        req.Method = "POST";
                        req.ContentType = "application/x-www-form-urlencoded";
                        break;

                    // POST request with attachments
                    case HTTPRequestType.MultipartPost:
                        mimePayload = new MIMEPayload();
                        postVars = null;
                        req.Method = "POST";
                        req.ContentType = "multipart/form-data; boundary=" + mimePayload.Boundary;
                        break;
                }
            }
        }

        /// <summary>
        /// Set to true to persist cookies between requests, false to discard cookies.
        /// Cookies will always be saved after a request so this flag only applies to whether
        /// the cookies are sent in the header of the next request (SendRequest()). If
        /// PersistCookies is set to false and a new request made, all cookies stored up to
        /// this point will be discarded.
        /// </summary>
        public bool PersistCookies
        {
            get
            {
                return persistCookies;
            }
            set
            {
                persistCookies = value;
            }
        }

        /// <summary>
        /// Add an argument to a POST request.
        /// </summary>
        /// <param name="key">Argument name</param>
        /// <param name="value">Argument value</param>
        public void AddValue( string key, string value )
        {
            if (postVars != null)
            {
                //postVars += ((postVars.Length > 0) ? "&" : "") + key + "=" + value;
                postVars += ((postVars.Length > 0) ? "&" : "") + System.Web.HttpUtility.UrlEncode(key) + "=" + System.Web.HttpUtility.UrlEncode(value);
            }

            if ( mimePayload != null )
                mimePayload.AddValue( key, value );
        }

        /// <summary>
        /// Add a file to a multi-part POST request.
        /// </summary>
        /// <param name="key">Argument name</param>
        /// <param name="value">Filename</param>
        public void AddFile( string key, string value )
        {
            if ( mimePayload == null )
                throw new Exception( "Must use MultipartPost method to add files." );

            mimePayload.AddFile( key, value );
        }

        /// <summary>
        /// Send the currently pending request.
        /// </summary>
        /// <returns>The HTTP response object</returns>
        public HttpWebResponse SendRequest()
        {
            Stream st = null;
            rsp = null;
            rspText = null;

            // Add previously stored cookies to the header if PersistCookies is on
            if ( persistCookies )
            {
                req.CookieContainer = new CookieContainer();
                foreach ( Cookie c in cookies )
                    req.CookieContainer.Add( c );
            }

            // Otherwise discard all previous cookies
            else
                cookies = new CookieCollection();

            // Create the request payload
            byte[] data = null;

            if ( req.Method == "GET" )
                data = new byte[0];

            if ( req.Method == "POST" && mimePayload == null )
                data = Encoding.ASCII.GetBytes( postVars );

            if ( req.Method == "POST" && mimePayload != null )
            {
                mimePayload.Finish();
                data = mimePayload.Data;
            }

            // Send the request payload if there is one (not applicable for GET requests)
            if ( data.Length > 0 )
            {
                try
                {
                    req.ContentLength = data.Length;
                    st = req.GetRequestStream();
                    st.Write( data, 0, data.Length );

                }
                catch ( WebException ex )
                {
                    throw ex;
                }
                finally
                {
                    if ( st != null )
                        st.Close();
                }
            }

            // Try to get the HTTP response
            try
            {
                rsp = (HttpWebResponse)req.GetResponse();
            }
            catch ( WebException ex )
            {
                throw ex;
            }

            // Remember newly sent cookies
            foreach ( Cookie c in rsp.Cookies )
                cookies.Add( c );

            // Return the response
            return rsp;
        }

        public HttpWebRequest RequestObject
        {
            get
            {
                return req;
            }
        }

        public HttpWebResponse ResponseObject
        {
            get
            {
                return rsp;
            }
        }

        public string ResponseText
        {
            get
            {
                if ( rspText == null )
                {
                    StreamReader sr = new StreamReader( rsp.GetResponseStream() );
                    rspText = sr.ReadToEnd();
                    sr.Close();
                }
                return rspText;
            }
        }

        public HttpStatusCode StatusCode
        {
            get
            {
                return rsp.StatusCode;
            }
        }

        public CookieCollection Cookies
        {
            get
            {
                return cookies;
            }
        }

        public HTTPWorker()
        {
            req = null;
            rsp = null;
            rspText = null;
            mimePayload = null;
            persistCookies = true;
            cookies = new CookieCollection();
        }
    }

    public class MIMEPayload
    {
        private const string boundary = "------------328523758298hjcwuie";
        private byte[] data = new byte[0];

        public void AddValue( string name, string value )
        {
            string text;
            text = "--" + boundary + "\r\n";
            text += "Content-Disposition: form-data; name=\"" + name + "\"\r\n\r\n";
            text += value + "\r\n";

            byte[] bytes = Encoding.ASCII.GetBytes( text );

            byte[] final = new byte[data.Length + bytes.Length];
            Buffer.BlockCopy( data, 0, final, 0, data.Length );
            Buffer.BlockCopy( bytes, 0, final, data.Length, bytes.Length );
            data = final;
        }

        public void AddFile( string name, string fileName )
        {
            string text;
            text = "--" + boundary + "\r\n";
            text += "Content-Disposition: form-data; name=\"" + name + "\"; filename=\"" + fileName + "\"\r\n";
            text += "Content-Type: application/octet-stream\r\n\r\n";

            byte[] textBytes = Encoding.ASCII.GetBytes( text );
            byte[] fileBytes;

            try
            {
                fileBytes = File.ReadAllBytes( fileName );
            }
            catch ( Exception )
            {
                fileBytes = new byte[0];
            }

            byte[] final = new byte[data.Length + textBytes.Length + fileBytes.Length + 2];
            Buffer.BlockCopy( data, 0, final, 0, data.Length );
            Buffer.BlockCopy( textBytes, 0, final, data.Length, textBytes.Length );
            Buffer.BlockCopy( fileBytes, 0, final, data.Length + textBytes.Length, fileBytes.Length );
            final[final.Length - 2] = 13;
            final[final.Length - 1] = 10;
            data = final;
        }

        public void Finish()
        {
            byte[] bytes = Encoding.ASCII.GetBytes( "--" + boundary + "--" );

            byte[] final = new byte[data.Length + bytes.Length];
            Buffer.BlockCopy( data, 0, final, 0, data.Length );
            Buffer.BlockCopy( bytes, 0, final, data.Length, bytes.Length );
            data = final;
        }

        public string Boundary
        {
            get
            {
                return boundary;
            }
        }

        public byte[] Data
        {
            get
            {
                return data;
            }
        }
    }
}