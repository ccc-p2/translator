using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Translator.Domain.Models
{
  /// <summary>
  /// The C# classes that represents the JSON returned by the Translator Text API.
  /// </summary> 
  public class TranslationResult
  {
      public DetectedLanguage DetectedLanguage { get; set; }
      public TextResult SourceText { get; set; }
      public Translation[] Translations { get; set; }
  }

  public class DetectedLanguage
  {
      public string Language { get; set; }
      public float Score { get; set; }
  }

  public class TextResult
  {
      public string Text { get; set; }
      public string Script { get; set; }
  }

  public class Translation
  {
      public string Text { get; set; }
      public TextResult Transliteration { get; set; }
      public string To { get; set; }
      public Alignment Alignment { get; set; }
      public SentenceLength SentLen { get; set; }
  }

  public class Alignment
  {
      public string Proj { get; set; }
  }

  public class SentenceLength
  {
      public int[] SrcSentLen { get; set; }
      public int[] TransSentLen { get; set; }
  }

  public class Translator
  {
    private const string key_var = "TRANSLATOR_TEXT_SUBSCRIPTION_KEY";
    // private static readonly string subscriptionKey = Environment.GetEnvironmentVariable(key_var);
    private static readonly string subscriptionKey = "49331ae9c7b548cdb0f97fb95b882d80";

    private const string endpoint_var = "TRANSLATOR_TEXT_ENDPOINT";
    // private static readonly string endpoint = Environment.GetEnvironmentVariable(endpoint_var);
    private static readonly string endpoint = "https://api-nam.cognitive.microsofttranslator.com/";


    static Translator()
    {
      if (null == subscriptionKey)
      {
          throw new Exception("Please set/export the environment variable: " + key_var);
      }
      if (null == endpoint)
      {
          throw new Exception("Please set/export the environment variable: " + endpoint_var);
      }
    }
    // Async call to the Translator Text API
    static private async Task<string> TranslateTextRequest(string subscriptionKey, string endpoint, string route, string inputText)
    {
      object[] body = new object[] { new { Text = inputText } };
      var requestBody = JsonConvert.SerializeObject(body);

      using (var client = new HttpClient())
      using (var request = new HttpRequestMessage())
      {
          // Build the request.
          request.Method = HttpMethod.Post;
          request.RequestUri = new Uri(endpoint + route);
          request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
          request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

          // Send the request and get response.
          HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
          // Read response as a string.
          string result = await response.Content.ReadAsStringAsync();
          TranslationResult[] deserializedOutput = JsonConvert.DeserializeObject<TranslationResult[]>(result);
          // Iterate over the deserialized results.
          if(deserializedOutput != null)
          {
            return deserializedOutput[0].Translations[0].Text;
          }
          
          /* foreach (TranslationResult o in deserializedOutput)
          {
              // Iterate over the results and print each translation.
              foreach (Translation t in o.Translations)
              {
                  return t.Text;
              }
          } */
              
          }
      }
      return null;
    }

    private static string GetLanguageCode(string lang)
    {
      var langMap = new Dictionary<string, string>();
      string route = "/languages?api-version=3.0";

      using (var client = new HttpClient())
      using (var request = new HttpRequestMessage())
      {
          // Set the method to GET
          request.Method = HttpMethod.Get;
          // Construct the full URI
          request.RequestUri = new Uri(endpoint + route);
          // Send request, get response
          var response = client.SendAsync(request).Result;
          var jsonResponse = response.Content.ReadAsStringAsync().Result;
          var deserialized = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
          // Print the response
          var translation = deserialized.translation;
          // create map <language name, language code>
          foreach(var langCode in translation)
          {
            foreach(var langName in langCode)
            {
              langMap.Add(langName.name.ToString().ToLower(), langCode.Name.ToString().ToLower());
            }
          }
      }
      if (langMap.ContainsKey(lang))
      {
        return langMap[lang];
      }
      return null;
    }
    public async Task<string> Translate(string message, string ToLanguage)
    {
      string langCode = GetLanguageCode(ToLanguage.ToLower());
      if(string.IsNullOrEmpty(langCode) || string.IsNullOrEmpty(message))
        return null;
      string route = "/translate?api-version=3.0&to="+langCode;
      string translatedText = await Task.FromResult(TranslateTextRequest(subscriptionKey, endpoint, route, message).Result);
      if(translatedText.Equals(message))
        return null;
      return translatedText;
    }
  }
}