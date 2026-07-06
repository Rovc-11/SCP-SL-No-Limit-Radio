// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="William">
// Copyright (c) William. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace OnBirsNoLimitRadio
{
    using Exiled.API.Interfaces;

    /// <summary>
    /// Telsiz pil tüketim hızını ayarlamak için kullanılan config sınıfı.
    /// </summary>
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc/>
        public bool Debug { get; set; } = false;

        /// <summary>
        /// Gets or sets telsizin pil tüketim hızı çarpanı.
        /// <para>
        /// 1.0 = vanilla (varsayılan) hız.<br/>
        /// 0.5 = pil, normalden 2 kat yavaş biter.<br/>
        /// 0.0 (veya daha küçük) = pil hiç tükenmez (sınırsız şarj).<br/>
        /// 2.0 = pil normalden 2 kat hızlı biter.
        /// </para>
        /// </summary>
        public float DrainMultiplier { get; set; } = 0f;
    }
}
