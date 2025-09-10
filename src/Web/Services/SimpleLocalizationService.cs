using System.Globalization;

namespace Microsoft.eShopWeb.Web.Services;

public interface ISimpleLocalizationService
{
    string GetString(string key);
}

public class SimpleLocalizationService : ISimpleLocalizationService
{
    private readonly Dictionary<string, Dictionary<string, string>> _translations = new()
    {
        ["en-US"] = new Dictionary<string, string>
        {
            ["Login"] = "Login",
            ["Logout"] = "Log Out",
            ["Admin"] = "Admin",
            ["MyOrders"] = "My orders",
            ["MyAccount"] = "My account",
            ["Catalog"] = "Catalog",
            ["Product"] = "Product",
            ["Price"] = "Price",
            ["Quantity"] = "Quantity",
            ["Cost"] = "Cost",
            ["Basket"] = "Basket",
            ["MyBasket"] = "My Basket",
            ["AddToBasket"] = "[ ADD TO BASKET ]",
            ["Checkout"] = "Checkout",
            ["Review"] = "Review",
            ["Brand"] = "brand",
            ["Type"] = "type",
            ["NoResultsMessage"] = "THERE ARE NO RESULTS THAT MATCH YOUR SEARCH",
            ["FooterText"] = "e-ShopOnWeb. All rights reserved",
            ["PlaceOrder"] = "PLACE ORDER",
            ["ContinueShopping"] = "CONTINUE SHOPPING",
            ["Update"] = "[ UPDATE ]",
            ["Total"] = "Total",
            ["Back"] = "[ Back ]",
            ["PayNow"] = "[ Pay Now ]",
            ["BasketEmpty"] = "Basket is empty."
        },
        ["de-DE"] = new Dictionary<string, string>
        {
            ["Login"] = "Anmelden",
            ["Logout"] = "Abmelden",
            ["Admin"] = "Administrator",
            ["MyOrders"] = "Meine Bestellungen",
            ["MyAccount"] = "Mein Konto",
            ["Catalog"] = "Katalog",
            ["Product"] = "Produkt",
            ["Price"] = "Preis",
            ["Quantity"] = "Menge",
            ["Cost"] = "Kosten",
            ["Basket"] = "Warenkorb",
            ["MyBasket"] = "Mein Warenkorb",
            ["AddToBasket"] = "[ ZUM WARENKORB HINZUFÜGEN ]",
            ["Checkout"] = "Zur Kasse",
            ["Review"] = "Überprüfung",
            ["Brand"] = "Marke",
            ["Type"] = "Typ",
            ["NoResultsMessage"] = "ES GIBT KEINE ERGEBNISSE, DIE IHRER SUCHE ENTSPRECHEN",
            ["FooterText"] = "e-ShopOnWeb. Alle Rechte vorbehalten",
            ["PlaceOrder"] = "BESTELLUNG AUFGEBEN",
            ["ContinueShopping"] = "WEITER EINKAUFEN",
            ["Update"] = "[ AKTUALISIEREN ]",
            ["Total"] = "Gesamt",
            ["Back"] = "[ Zurück ]",
            ["PayNow"] = "[ Jetzt bezahlen ]",
            ["BasketEmpty"] = "Warenkorb ist leer."
        }
    };

    public string GetString(string key)
    {
        var culture = CultureInfo.CurrentCulture.Name;
        
        if (_translations.ContainsKey(culture) && _translations[culture].ContainsKey(key))
        {
            return _translations[culture][key];
        }
        
        // Fallback to English
        if (_translations["en-US"].ContainsKey(key))
        {
            return _translations["en-US"][key];
        }
        
        return key; // Return key if translation not found
    }
}