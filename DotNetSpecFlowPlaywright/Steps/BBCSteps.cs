﻿using DotNetSpecFlowPlaywright.PageObjects;
using FluentAssertions;
using Microsoft.Playwright;
using System;
using System.Globalization;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace DotNetSpecFlowPlaywright.Steps
{
    [Binding]
    internal class BBCSteps

    {
        private CommonPageObjects _common;
        private IPage _page;

        public BBCSteps(IPage page, CommonPageObjects common)
        {
            _page = page;
            _common = common;
        }

        [Given(@"i navigate to ""(.*)""")]
        public async Task GivenINavigateTo(string p0)
        {
            await _common.GivenINavigateTo(p0);
        }

        [Then("i see current formula 1 driver table")]
        public async Task ThenISeeCurrentFormulaDriverTable()
        {
            string expected = await _page.InnerTextAsync("text=Lewis Hamilton");
            expected.Should().BeEquivalentTo("Lewis Hamilton");
        }

        [Then(@"i see current weather for ""(.*)""")]
        public async Task ThenISeeCurrentWeatherFor(string p0)
        {
            string expected = await _page.InnerTextAsync("//*[@id='wr-location-name-id']");
            expected.Should().BeEquivalentTo(p0);
        }

        [Then(@"i see stories for ""(.*)""")]
        public async Task ThenISeeStoriesFor(string p0)
        {
            var text = await _page.InnerTextAsync("span:has-text(\"Edinburgh, Fife & East Scotland\")");
            text.Should().BeEquivalentTo(p0);
        }

        [Then(@"i see todays Tv Guide")]
        public async Task ThenISeeTodaysTvGuide()
        {
            //Todays Date
            var date = System.DateTime.Now;
            var today = await _page.InnerTextAsync("//*[@class='day-switcher__item__day typo--bold'][contains(text(),'Today')]/../div[2]");
            var expectedDate = date.ToString("dd");
            today.Should().BeEquivalentTo(expectedDate);

            string timeFromPageText = await _page.InnerTextAsync("//*[@class='schedule-item schedule-item--live']/div/div[1]");
            var timeFromPage = DateTime.ParseExact(timeFromPageText, "HH:mm", CultureInfo.InvariantCulture).TimeOfDay;
            var time = date.TimeOfDay;
            //within one hour
            timeFromPage.Should().BeCloseTo(time, 3600000);
        }

        [When(@"click search")]
        public async Task WhenClickSearch()
        {
            // Press Enter
            await Task.WhenAll(
                _page.PressAsync("[placeholder=\"Enter a town, city or UK postcode\"]", "Enter"));
        }

        [When(@"i click channel ""(.*)""")]
        public async Task WhenIClickChannel(string p0)
        {
            var selector = $"//*[@href='#iplayer-icon-{p0.ToLower().Replace(" ", "")}-active']";
            await _page.ClickAsync(selector);
        }

        [When(@"i click menu ""(.*)""")]
        public async Task WhenIClickNewsMenu(string p0)
        {
            await _common.WhenIClickNewsMenu(p0);
        }

        [When(@"i input the location ""(.*)""")]
        public async Task WhenIInputTheLocation(string p0)
        {
            await _page.FillAsync("[placeholder=\"Enter a town, city or UK postcode\"]", p0);
        }
    }
}