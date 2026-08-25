using System.Web;

public static class OutputSanitizer {
    public static string EncodeForHtml(string input) {
        return HttpUtility.HtmlEncode(input);
    }
}
