﻿using AppCamera.Entities.Attributes;
using AppCamera.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using static AppCamera.Entities.Constants.ValidationMessages;
using static AppCamera.Entities.Constants.ValidationRegularExpressions;

namespace AppCamera.Entities.Enitities
{
    public class Camera
    {
        public int Id { get; set; }

        [Required]
        public Make Make { get; set; }
                      
        [Required, RegularExpression(CameraModelRegex, ErrorMessage = CameraModelValidationMessage)]             
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }
                            
        [Required, Range(0, 100)]
        public int Quantity { get; set; }

        [Required, Range(1, 30)]
        public int MinShutterSpeed { get; set; }

        [Required, Range(2000, 8000)]
        public int MaxShutterSpeed { get; set; }

        [MinIso, Required]
        public int MinIso { get; set; }

        [Required, Range(200, 409600), MaxIso]
        public int MaxIso { get; set; }
        
        public bool IsFullFrame { get; set; }

        [Required, StringLength(15)]
        public string VideoResolution { get; set; }
                   
        public LightMetering LightMetering { get; set; }

        [StringLength(6000), Required]
        public string Description { get; set; }

        [RegularExpression(ImageUrlRegex, ErrorMessage = ImageUrlMessage), Required]
        public string ImageUrl { get; set; }
    }
}
