<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MenteeMaster.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="MenteeAssignment.UI.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>
    <script type="text/javascript" src="script.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="wrap">
        <div class="main-greetings">
            Heyo, I'm Cyben.
        </div>
        <div class="main-header">
            I Dream to Design & Build
            <br />
            Beautiful Websites Someday!
        </div>
        <div class="main-details">
            <div class="main-details-header">
                Who am I.
            </div>
            <div class="main-details-details">
                I'm 24 year-old web designer dreamer. <br>
                I've been in a project as an application support and currently sitting here in IBM's bench.
                <br /><br />
                I want to be a professional web designer someday, 
                just like <a href="http://www.alphadiv.com">Alexandru Cohaniuc</a> who created this webpage concept.
            </div>
            <div class="main-details-header">
                What I can do.
            </div>
            <div class="main-details-details">
                <ul>
                    <li>Learn CMS driven websites: blogs, magazines, Wordpress and Drupal themes</li>
                    <li>Learn presentation websites and landing pages</li>
                    <li>Learn mobile websites and interfaces for mobile applications</li>
                    <li>Learn PSD to HTML services</li>
                    <li>Learn vector illustrations and stock imagery</li>
                    <li>Learn logo design, stationary and branding</li>
                    <li>Dream</li>
                </ul>
            </div>
            <div class="main-details-header">
                Get in touch.
            </div>
            <div class="main-details-details">
                Email Address: <a>cybenlainez@gmail.com</a>
                <br />
                Contact No.: +63 936 565 3123               
            </div>
        </div>
        <div id="main-image">
    	    <div id="retina"></div>
        </div>
    </div>

</asp:Content>
