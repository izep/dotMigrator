using System;
using System.Collections;
using System.Collections.Generic;

namespace dotMigrator
{
	public interface IJournal
	{
		/// <summary>
		/// Creates a table, file, collection etc.
		/// This should be a no-op if the journal already exists.
		/// </summary>
		void CreateJournal();

		void SetBaseline(string lastMigrationToBaseline, IMigrationsProvider migrationsProvider);


		void RecordStartMigration(Migration migrationToRun);
		void RecordCompleteMigration(Migration migrationToRun);
		void RecordStoredCodeDefinition(StoredCodeDefinition storedCodeDefinition, int lastMigrationNumber);
		/// <summary>
		/// Returns the sequenced list of offline and online migrations that have been recorded in the journal
		/// </summary>
		/// <exception cref="InvalidOperationException">If the journal was never created for the target data store</exception>
		IReadOnlyList<DeployedMigration> GetDeployedMigrations();
		IReadOnlyList<DeployedStoredCodeDefinition> GetDeployedStoredCodeDefinitions();
	}
}