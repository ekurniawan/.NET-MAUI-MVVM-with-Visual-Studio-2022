﻿using System;
using System.Net.Http.Json;
using ContohMVVM.Models;

namespace ContohMVVM.Services
{
	public class MonkeyService
	{
		HttpClient httpClient;
		public MonkeyService()
		{
			httpClient = new HttpClient();
		}

		List<Monkey> monkeyList = new();
		public async Task<List<Monkey>> GetMonkeys()
		{
			if (monkeyList?.Count > 0)
				return monkeyList;

            var url = "https://www.montemagno.com/monkeys.json";
			var response = await httpClient.GetAsync(url);
			if(response.IsSuccessStatusCode)
			{
				monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
			}
			return monkeyList;
        }
	}
}
