﻿// This file was auto-generated by ML.NET Model Builder.
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace SweetNela.MLintegration
{
    public partial class ProductRecommender
    {
        /// <summary>
        /// model input class for ProductRecommender.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [LoadColumn(0)]
            [ColumnName(@"userId")]
            public string UserId { get; set; }

            [LoadColumn(1)]
            [ColumnName(@"productId")]
            public float ProductId { get; set; }

            [LoadColumn(2)]
            [ColumnName(@"Label")]
            public float Label { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for ProductRecommender.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"userId")]
            public string UserId { get; set; }

            [ColumnName(@"productId")]
            public float ProductId { get; set; }

            [ColumnName(@"Label")]
            public float Label { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("MLintegration/ProductRecommender.mlnet");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);


        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }
    }
}
