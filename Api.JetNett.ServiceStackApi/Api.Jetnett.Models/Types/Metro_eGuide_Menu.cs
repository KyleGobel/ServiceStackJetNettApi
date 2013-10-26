using System;
using System.Collections.Generic;
using Api.Jetnett.Models.Types;

namespace Api.Jetnett.Models.Models
{
    public partial class Metro_eGuide_Menu
    {
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string cssBackgroundColor { get; set; }
        public string cssOverBackgroundColor { get; set; }
        public string cssColor { get; set; }
        public string cssOverColor { get; set; }
        public string cssBorderColor { get; set; }
        public string cssOverBorderColor { get; set; }
        public string cssFontFamily { get; set; }
        public string cssBorderSize { get; set; }
        public string button2Text { get; set; }
        public string button3Text { get; set; }
        public string button4Text { get; set; }
        public string button5Text { get; set; }
        public string button6Text { get; set; }
        public string button7Text { get; set; }
        public string button2URL { get; set; }
        public string button3URL { get; set; }
        public string button4URL { get; set; }
        public string button5URL { get; set; }
        public string button6URL { get; set; }
        public string button7URL { get; set; }
        public string homeSearch1Text { get; set; }
        public string homeSearch2Text { get; set; }
        public string homeSearch3Text { get; set; }
        public string homeSearch4Text { get; set; }
        public string homeSearch5Text { get; set; }
        public string homeSearch6Text { get; set; }
        public string homeSearch7Text { get; set; }
        public string homeSearch8Text { get; set; }
        public string homeSearch1URL { get; set; }
        public string homeSearch2URL { get; set; }
        public string homeSearch3URL { get; set; }
        public string homeSearch4URL { get; set; }
        public string homeSearch5URL { get; set; }
        public string homeSearch6URL { get; set; }
        public string homeSearch7URL { get; set; }
        public string homeSearch8URL { get; set; }
        public string companyName { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string graphicsLocation { get; set; }
        public string phoneNumber2 { get; set; }
        public string faxNumber { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string otherInformation { get; set; }
        public string mapURL { get; set; }
        public string cssBodyBackground { get; set; }
        public string areaTitle { get; set; }
        public string centerGraphicURL { get; set; }
        public string areaTitleSize { get; set; }
        public string areaTitleColor { get; set; }
        public string rButton1Text { get; set; }
        public string rButton2Text { get; set; }
        public string rButton3Text { get; set; }
        public string rButton4Text { get; set; }
        public string rButton5Text { get; set; }
        public string rButton6Text { get; set; }
        public string rButton7Text { get; set; }
        public string rButton8Text { get; set; }
        public string rButton1URL { get; set; }
        public string rButton2URL { get; set; }
        public string rButton3URL { get; set; }
        public string rButton4URL { get; set; }
        public string rButton5URL { get; set; }
        public string rButton6URL { get; set; }
        public string rButton7URL { get; set; }
        public string rButton8URL { get; set; }
        public string centerGraphicBorderColor { get; set; }
        public string centerGraphicBorderSize { get; set; }
        public Nullable<bool> button2NewWindow { get; set; }
        public Nullable<bool> button3NewWindow { get; set; }
        public Nullable<bool> button4NewWindow { get; set; }
        public Nullable<bool> button5NewWindow { get; set; }
        public Nullable<bool> button6NewWindow { get; set; }
        public Nullable<bool> button7NewWindow { get; set; }
        public Nullable<bool> button8NewWindow { get; set; }
        public string button2Target { get; set; }
        public string button3Target { get; set; }
        public string button4Target { get; set; }
        public string button5Target { get; set; }
        public string button6Target { get; set; }
        public string button7Target { get; set; }
        public string button8Target { get; set; }
        public string button1Text { get; set; }
        public string button1URL { get; set; }
        public string button8Text { get; set; }
        public string button8URL { get; set; }
        public string leftMenuGraphicURL { get; set; }
        public string centerGraphicTarget { get; set; }
        public string centerGraphic { get; set; }
        public string centerGraphicLinkURL { get; set; }
        public virtual Client Client { get; set; }
    }
}
