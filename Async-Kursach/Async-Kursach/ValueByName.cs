﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Async_Kursach
{
	public class ValueByName
	{
		const string defaultString = "Valentyn";
		public async Task LoadValue(string text)
		{
			string url;
			if (text!= defaultString)
			{
				url = $"https://api.agify.io?name={ text } ";
			}
			else
			{
				url = $"https://api.agify.io?name={ defaultString }";
			}

			//open a call to a client
			//or open a new request of ApiClient as await for response
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
			{
				if (response.IsSuccessStatusCode)
				{
					// there We will read the data

				}
			}
			//there a response is closing and make sure, that Our calls are cleaned up
		}
	}
}
