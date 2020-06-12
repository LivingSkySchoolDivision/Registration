using System;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace LSSD.Registration.FormGenerators.Common {
    class LSSDDocumentStyles {
        private static StyleDefinitionsPart addStylePrerequisites(WordprocessingDocument doc)
        {
            if (doc?.MainDocumentPart?.StyleDefinitionsPart == null) {
                StyleDefinitionsPart part;
                part = doc.MainDocumentPart.AddNewPart<StyleDefinitionsPart>();
                Styles root = new Styles();
                root.Save(part);
                return part;
            } else {
                return doc.MainDocumentPart.StyleDefinitionsPart;
            }
        }

        public static void AddStylesToDocument(WordprocessingDocument doc) {
            // This is stupid and Microsoft should feel bad for how this whole SDK works
            addStyles(addStylePrerequisites(doc));
        }

        private static void addStyles(StyleDefinitionsPart stylePart) 
            {
                if (stylePart.Styles == null)
                {
                    stylePart.Styles = new Styles();
                    stylePart.Styles.Save();
                }

                // Create a new paragraph style element and specify some of the attributes.
                stylePart.Styles.Append(new Style(
                    new PrimaryStyle() { Val = OnOffOnlyValues.On }, // Should it show up in the list of styles in the editor
                    new StyleName() { Val = "Page Title" }
                ) { 
                    Type = StyleValues.Paragraph,
                    StyleId = "Page Title",
                    CustomStyle = true,
                    Default = false,
                    StyleRunProperties = new StyleRunProperties(
                        new Bold(), 
                        new Color() { ThemeColor = ThemeColorValues.Accent1 }, 
                        new RunFonts() { Ascii = "Arial" },
                        new FontSize() { Val = "36" } // Double the font size value you see in Word
                    )
                });

                stylePart.Styles.Append(new Style(
                    new PrimaryStyle() { Val = OnOffOnlyValues.On }, // Should it show up in the list of styles in the editor
                    new StyleName() { Val = "Section Title" }
                ) { 
                    Type = StyleValues.Paragraph,
                    StyleId = "Section Title",
                    CustomStyle = true,
                    Default = false,
                    StyleRunProperties = new StyleRunProperties(
                        new Color() { ThemeColor = ThemeColorValues.Accent1 }, 
                        new RunFonts() { Ascii = "Arial" },
                        new FontSize() { Val = "28" } // Double the font size value you see in Word
                    )
                });

                stylePart.Styles.Append(new Style(
                    new PrimaryStyle() { Val = OnOffOnlyValues.On }, // Should it show up in the list of styles in the editor
                    new StyleName() { Val = "Field Label" }
                ) { 
                    Type = StyleValues.Paragraph,
                    StyleId = "Field Label",
                    CustomStyle = true,
                    Default = false,
                    StyleRunProperties = new StyleRunProperties(
                        new Bold(), 
                        new Color() { ThemeColor = ThemeColorValues.Text1 }, 
                        new RunFonts() { Ascii = "Arial" },
                        new FontSize() { Val = "16" } // Double the font size value you see in Word
                    )
                });
                
                stylePart.Styles.Append(new Style(
                    new PrimaryStyle() { Val = OnOffOnlyValues.On }, // Should it show up in the list of styles in the editor
                    new StyleName() { Val = "Field Value" }
                ) { 
                    Type = StyleValues.Paragraph,
                    StyleId = "Field Value",
                    CustomStyle = true,
                    Default = false,
                    StyleRunProperties = new StyleRunProperties(
                        new Color() { ThemeColor = ThemeColorValues.Text1 }, 
                        new RunFonts() { Ascii = "Arial" },
                        new FontSize() { Val = "16" } // Double the font size value you see in Word
                    )
                });
            }
    }
}