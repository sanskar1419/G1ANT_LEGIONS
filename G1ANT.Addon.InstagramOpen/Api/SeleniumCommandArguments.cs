using G1ANT.Language;

namespace G1ANT.Addon.Instagram
{
    public class SeleniumCommandArguments : SeleniumIFrameArguments
    {
        [Argument(Tooltip = "Phrase to find an element by")]
        public TextStructure Search { get; set; }

        [Argument(Tooltip = "Specifies an element selector: 'id', 'class', 'cssselector', 'tag', 'xpath', 'name', 'query', 'jquery'")]
        public TextStructure By { get; set; } = new TextStructure(ElementSearchBy.Id.ToString().ToLower());
    }
}
