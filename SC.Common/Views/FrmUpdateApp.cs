using SC.Common.Model;
using SC.Common.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SC.Common.Views
{
	public partial class FrmUpdateApp : NoBorderForm
	{
		public FrmUpdateApp(CVersionHistory[] versions)
		{
			try
			{
				InitializeComponent();

				Update(versions);
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}

		private void Update(CVersionHistory[] versions)
		{
			try
			{
				var titleColors = new Dictionary<CVersionHistory.VersionSerious, Color>
				{
					[CVersionHistory.VersionSerious.Standard] = Color.DimGray,
					[CVersionHistory.VersionSerious.Serious] = Color.FromArgb(255, 150, 0),
					[CVersionHistory.VersionSerious.Critical] = Color.FromArgb(200, 50, 50)
				};
				pnVersions.Controls.Clear();

				foreach (var version in versions)
				{
					var title = new Label
					{
						AutoSize = true,
						Dock = DockStyle.Top,
						Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold),
						ForeColor = titleColors[version.Serious],
						Location = new Point(0, 186),
						MinimumSize = new Size(Width, 0),
						MaximumSize = new Size(Width, 0),
						Padding = new Padding(25, 5, 25, 0),
						Size = new Size(700, 165),
						Text = $"Версия {version.Version} от {version.DateTime:d}",
						TextAlign = ContentAlignment.TopCenter
					};
					if (version.Serious == CVersionHistory.VersionSerious.Serious)
					{
						title.Text += " (важное обновление)";
					}
					if (version.Serious == CVersionHistory.VersionSerious.Critical)
					{
						title.Text += " (критическое обновление)";
					}
					var descr = new Label
					{
						AutoSize = true,
						Dock = DockStyle.Top,
						ForeColor = Color.DimGray,
						Location = new Point(0, 186),
						MinimumSize = new Size(Width, 0),
						MaximumSize = new Size(Width, 0),
						Padding = new Padding(25, 0, 25, 5),
						Size = new Size(700, 165),
						Text = version.Description,
						TextAlign = ContentAlignment.TopCenter
					};
					pnVersions.Controls.Add(title);
					title.BringToFront();
					pnVersions.Controls.Add(descr);
					descr.BringToFront();
				}
			}
			catch (Exception ex)
			{
				CBugDto.Report(ex, this);
			}
		}
	}
}