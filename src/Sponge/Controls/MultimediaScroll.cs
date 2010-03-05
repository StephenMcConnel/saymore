// ---------------------------------------------------------------------------------------------
#region // Copyright (c) 2010, SIL International. All Rights Reserved.
// <copyright from='2010' to='2010' company='SIL International'>
//		Copyright (c) 2010, SIL International. All Rights Reserved.
//
//		Distributable under the terms of either the Common Public License or the
//		GNU Lesser General Public License, as specified in the LICENSING.txt file.
// </copyright>
#endregion
//
// File: MultimediaScroll.cs
// Responsibility: D. Olson
//
// <remarks>
// </remarks>
// ---------------------------------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AxWMPLib;
using SIL.Sponge.Properties;
using SilUtils;
using SilUtils.Controls;

namespace SIL.Sponge.Controls
{
	/// ----------------------------------------------------------------------------------------
	/// <summary>
	///
	/// </summary>
	/// ----------------------------------------------------------------------------------------
	public class MultimediaScroll : UserControl
	{
		private int m_topOfNextCtrl;
		private readonly SilPanel m_pnl;

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="MultimediaScroll"/> class.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		public MultimediaScroll()
		{
			DoubleBuffered = true;

			// Provides the border
			m_pnl = new SilPanel();
			m_pnl.Dock = DockStyle.Fill;
			m_pnl.AutoScroll = true;
			m_pnl.VerticalScroll.Visible = true;
			m_pnl.HorizontalScroll.Visible = false;
			m_pnl.BackColor = Color.DarkGray;

			Controls.Add(m_pnl);
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Gets or sets the background color for the control.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		public override Color BackColor
		{
			get { return base.BackColor; }
			set
			{
				base.BackColor = value;
				m_pnl.BackColor = value;
			}
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Clears this instance.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		public void Clear()
		{
			for (int i = m_pnl.Controls.Count - 1; i >= 0; i--)
			{
				if (m_pnl.Controls[i] is AxWindowsMediaPlayer)
					((AxWindowsMediaPlayer)m_pnl.Controls[i]).Ctlcontrols.stop();

				m_pnl.Controls[i].Dispose();
			}

			m_pnl.Controls.Clear();
			m_topOfNextCtrl = 0;
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Adds the list of files.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		public void AddFiles(IEnumerable<string> list)
		{
			Utils.SetWindowRedraw(this, false);

			foreach (var file in list)
				AddFile(file);

			Utils.SetWindowRedraw(this, true);
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Adds the specified file.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		public void AddFile(string file)
		{
			if (!File.Exists(file))
				return;

			var ext = Path.GetExtension(file);

			if (Settings.Default.AudioFileExtensions.Contains(ext))
				AddAVFile(file, false);
			else if (Settings.Default.VideoFileExtensions.Contains(ext))
				AddAVFile(file, true);
			else if (Settings.Default.ImageFileExtensions.Contains(ext))
				AddImageFile(file);
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Adds a control for the specified image file.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		private void AddImageFile(string file)
		{
			// Do this instead of using the Load method because Load keeps a lock on the file.
			var fs = new FileStream(file, FileMode.Open, FileAccess.Read);
			var img = Image.FromStream(fs);
			fs.Close();
			fs.Dispose();

			var pic = new PictureBox();
			pic.Size = new Size(m_pnl.ClientSize.Width,
				Settings.Default.DefaultHeightOfImageControl);

			pic.Location = new Point(0, m_topOfNextCtrl);
			pic.Anchor |= AnchorStyles.Right;
			pic.Name = Path.GetFileName(file);
			pic.SizeMode = PictureBoxSizeMode.Zoom;
			pic.Image = img;
			m_pnl.Controls.Add(pic);
			m_topOfNextCtrl += pic.Height + Settings.Default.GapBetweenMultimediaObjects;
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Adds a control for the specified audio or video file.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		private void AddAVFile(string file, bool isVideoFile)
		{
			var pt = new Point(0, m_topOfNextCtrl);
			var sz = new Size(m_pnl.ClientSize.Width, isVideoFile ?
				Settings.Default.DefaultHeightOfVideoControl :
				Settings.Default.DefaultHeightOfAudioControl);
#if !MONO
			var wmp = new AxWindowsMediaPlayer();
			((ISupportInitialize)(wmp)).BeginInit();
			//wmp.OcxState = (AxHost.State)Resources.wmpOcxState;
			wmp.Size = sz;
			wmp.Location = pt;
			wmp.Anchor |= AnchorStyles.Right;
			wmp.Name = Path.GetFileName(file);
			wmp.Tag = file;
			m_pnl.Controls.Add(wmp);
			((ISupportInitialize)(wmp)).EndInit();
			wmp.settings.autoStart = false;
			wmp.URL = file;
#endif
			m_topOfNextCtrl += wmp.Height + Settings.Default.GapBetweenMultimediaObjects;
		}
	}
}