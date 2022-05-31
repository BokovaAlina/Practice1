using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practice1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            dictionary.Add("Alina", "123");
            dictionary.Add("Sergey", "456");
            dictionary.Add("Denis", "789");
            dictionary.ChangeKey("Alina", "alina");
            dictionary.ChangeKey("Sergey", "sergey");
            dictionary.ChangeKey("Denis", "denis");
        }

        protected void Button1_SignIn(object sender, EventArgs e)
        {
            if (dictionary.ContainsKey(TextBox1.Text.ToLower()))
                if (dictionary[TextBox1.Text.ToLower()] == TextBox2.Text)
                    Response.Redirect("WebForm2.aspx");
                else
                    Label3.Text = "Wrong login or password";
            else
                Label3.Text = "Wrong login or password";
        }
       
    }
    public static class Extensions
    {
        public static bool ChangeKey<TKey, TValue>(this IDictionary<TKey, TValue> dict,
            TKey oldKey, TKey newKey)
        {
            TValue value;
            if (!dict.TryGetValue(oldKey, out value))
                return false;

            dict.Remove(oldKey);
            dict[newKey] = value;  // or dict.Add(newKey, value) depending on ur comfort
            return true;
        }
    }
}