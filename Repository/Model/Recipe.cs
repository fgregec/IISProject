using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Repository.Model
{
    public partial class Recipe
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }

    }

    public partial class Result
    {
        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        [JsonProperty("show")]
        public Show Show { get; set; }

        [JsonProperty("original_video_url")]
        public Uri OriginalVideoUrl { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("sections")]
        public List<Section> Sections { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("yields")]
        public string Yields { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("prep_time_minutes")]
        public long PrepTimeMinutes { get; set; }

        [JsonProperty("draft_status")]
        public string DraftStatus { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("credits")]
        public List<Credit> Credits { get; set; }

        [JsonProperty("cook_time_minutes")]
        public long CookTimeMinutes { get; set; }

        [JsonProperty("num_servings")]
        public long NumServings { get; set; }

        [JsonProperty("nutrition")]
        public Nutrition Nutrition { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("video_url")]
        public Uri VideoUrl { get; set; }

        [JsonProperty("renditions")]
        public List<Rendition> Renditions { get; set; }

        [JsonProperty("instructions")]
        public List<Instruction> Instructions { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("thumbnail_url")]
        public Uri ThumbnailUrl { get; set; }

        [JsonProperty("total_time_minutes")]
        public long TotalTimeMinutes { get; set; }

        [JsonProperty("user_ratings")]
        public UserRatings UserRatings { get; set; }
    }

    public partial class Credit
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Instruction
    {
        [JsonProperty("temperature")]
        public object Temperature { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("display_text")]
        public string DisplayText { get; set; }

        [JsonProperty("start_time")]
        public long StartTime { get; set; }

        [JsonProperty("appliance")]
        public object Appliance { get; set; }

        [JsonProperty("end_time")]
        public long EndTime { get; set; }
    }

    public partial class Nutrition
    {
    }

    public partial class Rendition
    {
        [JsonProperty("poster_url")]
        public Uri PosterUrl { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("aspect")]
        public string Aspect { get; set; }

        [JsonProperty("minimum_bit_rate")]
        public long? MinimumBitRate { get; set; }

        [JsonProperty("maximum_bit_rate")]
        public long? MaximumBitRate { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("container")]
        public string Container { get; set; }

        [JsonProperty("file_size")]
        public long? FileSize { get; set; }

        [JsonProperty("bit_rate")]
        public long? BitRate { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Section
    {
        [JsonProperty("components")]
        public List<Component> Components { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }
    }

    public partial class Component
    {
        [JsonProperty("raw_text")]
        public string RawText { get; set; }

        [JsonProperty("extra_comment")]
        public string ExtraComment { get; set; }

        [JsonProperty("ingredient")]
        public Ingredient Ingredient { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("measurements")]
        public List<Measurement> Measurements { get; set; }
    }

    public partial class Ingredient
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("display_plural")]
        public string DisplayPlural { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("display_singular")]
        public string DisplaySingular { get; set; }

        [JsonProperty("updated_at")]
        public long UpdatedAt { get; set; }
    }

    public partial class Measurement
    {
        [JsonProperty("unit")]
        public Unit Unit { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public partial class Unit
    {
        [JsonProperty("system")]
        public VideoAdContent System { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("display_plural")]
        public string DisplayPlural { get; set; }

        [JsonProperty("display_singular")]
        public string DisplaySingular { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }
    }

    public partial class Show
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public partial class Tag
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }

    public partial class TotalTimeTier
    {
        [JsonProperty("display_tier")]
        public string DisplayTier { get; set; }

        [JsonProperty("tier")]
        public string Tier { get; set; }
    }

    public partial class UserRatings
    {
        [JsonProperty("count_positive")]
        public long CountPositive { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("count_negative")]
        public long CountNegative { get; set; }
    }

    public enum VideoAdContent { Imperial, Metric, None };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                VideoAdContentConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class VideoAdContentConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(VideoAdContent) || t == typeof(VideoAdContent?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "imperial":
                    return VideoAdContent.Imperial;
                case "metric":
                    return VideoAdContent.Metric;
                case "none":
                    return VideoAdContent.None;
            }
            throw new Exception("Cannot unmarshal type VideoAdContent");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (VideoAdContent)untypedValue;
            switch (value)
            {
                case VideoAdContent.Imperial:
                    serializer.Serialize(writer, "imperial");
                    return;
                case VideoAdContent.Metric:
                    serializer.Serialize(writer, "metric");
                    return;
                case VideoAdContent.None:
                    serializer.Serialize(writer, "none");
                    return;
            }
            throw new Exception("Cannot marshal type VideoAdContent");
        }

        public static readonly VideoAdContentConverter Singleton = new VideoAdContentConverter();
    }
}
