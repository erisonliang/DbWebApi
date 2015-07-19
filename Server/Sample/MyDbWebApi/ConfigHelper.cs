﻿using System.Configuration;

namespace MyDbWebApi
{
	public static class ConfigHelper
	{
		private const string _UserNameReservedParameterSettingKey = "UserNameReservedParameter";
		private const string _CorsOriginsSettingKey = "CorsOrigins";
		private const string _SupportsCredentialsSettingKey = "CorsSupportsCredentials";

		private static string _UserNameReservedParameter = null;
		public static string UserNameReservedParameter
		{
			get
			{
				if (_UserNameReservedParameter == null)
				{
					_UserNameReservedParameter = ConfigurationManager.AppSettings[_UserNameReservedParameterSettingKey];

					if (_UserNameReservedParameter == null)
						_UserNameReservedParameter = string.Empty;
				}

				return _UserNameReservedParameter;
			}
			set
			{
				_UserNameReservedParameter = value;
			}
		}

		private static string _CorsOrigins = null;
		public static string CorsOrigins
		{
			get
			{
				if (_CorsOrigins == null)
				{
					_CorsOrigins = ConfigurationManager.AppSettings[_CorsOriginsSettingKey];

					if (_CorsOrigins == null)
						_CorsOrigins = string.Empty;
				}

				return _CorsOrigins;
			}
			set
			{
				_CorsOrigins = value;
			}
		}

		private static bool? _SupportsCredentials = null;
		public static bool SupportsCredentials
		{
			get
			{
				if (_SupportsCredentials == null)
				{
					string withCredentials = ConfigurationManager.AppSettings[_SupportsCredentialsSettingKey];
					bool bCredentials = false;

					if (!string.IsNullOrEmpty(withCredentials))
						bool.TryParse(withCredentials, out bCredentials);

					_SupportsCredentials = bCredentials;
				}

				return _SupportsCredentials.Value;
			}
			set
			{
				ConfigHelper._SupportsCredentials = value;
			}
		}

	}
}