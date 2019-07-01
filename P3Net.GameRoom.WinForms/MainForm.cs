/*
 * Copyright © 2018 Michael Taylor
 * https://www.michaeltaylorp3.net
 *
 * All Rights Reserved
 */
using System;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace P3Net.GameRoom.WinForms
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm ()
        {
            InitializeComponent();

            _gridCollection.AutoGenerateColumns = false;
        }
        #endregion

        protected override async void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            CreateContainer();

            await LoadGamesAsync(CancellationToken.None);
        }
        #region Event Handlers

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            MessageBox.Show(this, Application.ProductVersion, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Private Members

        //TODO: Use a DI container
        private void CreateContainer ()
        {
            var options = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder()
                                        .UseSqlServer(ConfigurationManager.ConnectionStrings["GameDatabase"].ConnectionString);

            _gameRepository = new SqlServer.SqlGameRepository(() => options.Options);
        }

        //TODO: Move to user control
        private async Task LoadGamesAsync ( CancellationToken cancellationToken )
        {
            var games = await _gameRepository.GetInCollectionAsync(cancellationToken);

            var binding = new BindingSource();
            binding.DataSource = games ?? Enumerable.Empty<Game>();
            _gridCollection.DataSource = binding;
        }

        //TODO: Wrap with UoW
        private IGameRepository _gameRepository;
        #endregion
    }
}
