using System.Net;

namespace LighterApp;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private void OnCounterClicked(object sender, EventArgs e)
    {   
        // TODO: Error handling [ Error message etc.]
        // check for input TODO: this check doesnt work at all
        if (rEntry.Text == null || gEntry.Text == null || bEntry.Text == null)
            return;

        // convert text to int
        int rValue = Convert.ToInt32(rEntry.Text);
        int gValue = Convert.ToInt32(gEntry.Text);
        int bValue = Convert.ToInt32(bEntry.Text);

        // check for valid input
        if (rValue < 0 || rValue > 255)
            return;
        if (gValue < 0 || gValue > 255)
            return;
        if (gValue < 0 || gValue > 255)
            return;

        // TODO: URI is Hardcoded, pls change!
        var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://192.168.178.62/post");
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";

        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = "{\"r\":\"" + rValue + "\",\"g\":\"" + gValue + "\",\"b\":\"" + bValue + "\"}";

            streamWriter.Write(json);
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            // Console.Write(result);
        }
    }
}

