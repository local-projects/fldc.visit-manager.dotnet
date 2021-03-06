﻿using Newtonsoft.Json;
using Squidex.ClientLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace FLDCVisitManager.CMSDataLayar.DTO
{
    public class ImageAsset : Content<ImageAssetData>
    {

    }
    public partial class ImageAssetData
    {
        public string Iv { get; set; }

        [JsonProperty("ImageAsset")]
        public ImageAssetClass ImageAsset { get; set; }

        [JsonProperty("Caption")]
        public Caption Caption { get; set; }

        [JsonProperty("Credit")]
        public Caption Credit { get; set; }

        [JsonProperty("Values")]
        public Values Values { get; set; }

        [JsonProperty("ShowInShopify")]
        public ShowInShopify ShowInShopify { get; set; }

        [JsonProperty("ShopifyIcon")]
        public ShopifyIcon ShopifyIcon { get; set; }
    }

    public partial class Caption
    {
        [JsonProperty("iv")]
        public string Iv { get; set; }
    }

    public partial class ShopifyIcon
    {
        [JsonProperty("iv")]
        public List<string> Iv { get; set; }
    }

    public partial class ShowInShopify
    {
        [JsonProperty("iv")]
        public bool Iv { get; set; }
    }

    public partial class ImageAssetClass
    {
        [JsonProperty("iv")]
        public List<string> Iv { get; set; }
    }

    public partial class Values
    {
        [JsonProperty("iv")]
        public List<Iv> Iv { get; set; }
    }

    public partial class Iv
    {
        [JsonProperty("StringValue")]
        public string StringValue { get; set; }

        [JsonProperty("ValueNumber")]
        public string ValueNumber { get; set; }
    }
}

