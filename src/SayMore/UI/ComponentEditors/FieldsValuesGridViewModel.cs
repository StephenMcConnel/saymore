using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SayMore.Model.Fields;
using SayMore.Model.Files;
using SayMore.Model.Files.DataGathering;

namespace SayMore.UI.ComponentEditors
{
	/// ----------------------------------------------------------------------------------------
	/// <summary>
	///
	/// </summary>
	/// ----------------------------------------------------------------------------------------
	public class FieldsValuesGridViewModel
	{
		private readonly FieldGatherer _fieldGatherer;
		private ComponentFile _file;

		public Action ComponentFileChanged;
		//public List<KeyValuePair<FieldDefinition, FieldInstance>> RowData { get; private set; }
		public List<FieldInstance> RowData { get; private set; }

		private Dictionary<string, IEnumerable<string>> _autoCompleteLists = new Dictionary<string,IEnumerable<string>>();
		private readonly IMultiListDataProvider _autoCompleteProvider;
		private IEnumerable<FieldDefinition> _fieldDefsForFile;

		public Func<string, bool> _includedFieldFilterFunction;

		/// ------------------------------------------------------------------------------------
		public FieldsValuesGridViewModel(ComponentFile file, IMultiListDataProvider autoCompleteProvider,
			FieldGatherer fieldGatherer, Func<string, bool> includedFieldFilterFunction)
		{
			_fieldGatherer = fieldGatherer;
			_includedFieldFilterFunction = includedFieldFilterFunction;

			if (autoCompleteProvider != null)
			{
				_autoCompleteProvider = autoCompleteProvider;
				_autoCompleteProvider.NewDataAvailable += HandleNewAutoCompleteDataAvailable;
				_autoCompleteLists = _autoCompleteProvider.GetValueLists();
			}

			SetComponentFile(file);
		}

		/// ------------------------------------------------------------------------------------
		public void SetComponentFile(ComponentFile file)
		{
			_file = file;
			RowData = new List<FieldInstance>();
			LoadFields();

			if (ComponentFileChanged != null)
				ComponentFileChanged();
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Load the field values into the model's data cache.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		public void LoadFields()
		{
			var factoryFields = _file.FileType.FactoryFields;
			_fieldDefsForFile = factoryFields.Union(_fieldGatherer.GetAllFieldsForFileType(_file.FileType).Where(f => !factoryFields.Any(e => e.Key == f.Key)));

			foreach (var field in _fieldDefsForFile)
			{
				if (_includedFieldFilterFunction != null && !_includedFieldFilterFunction(field.Key))
					continue;

				//TODO: make use of field.ReadOnly

				var fieldValue = new FieldInstance(field.Key, _file.GetStringValue(field.Key, string.Empty));
				RowData.Add(fieldValue);
			}
		}

		/// ------------------------------------------------------------------------------------
		public string GridSettingsName
		{
			get { return _file.FileType.FieldsGridSettingsName; }
		}

		/// ------------------------------------------------------------------------------------
		void HandleNewAutoCompleteDataAvailable(object sender, EventArgs e)
		{
			_autoCompleteLists = _autoCompleteProvider.GetValueLists();
		}

		/// ------------------------------------------------------------------------------------
		public AutoCompleteStringCollection GetAutoCompleteListForIndex(int index)
		{
			var fieldId = GetIdForIndex(index);
			var autoCompleteValues = new AutoCompleteStringCollection();

			if (!string.IsNullOrEmpty(fieldId))
			{
				IEnumerable<string> values;
				if (_autoCompleteLists.TryGetValue(fieldId, out values))
					autoCompleteValues.AddRange(values.ToArray());
			}

			return autoCompleteValues;
		}

		/// ------------------------------------------------------------------------------------
		private FieldDefinition GetFieldDefinitionForIndex(int index)
		{
			return (index >= RowData.Count ? null :
				_fieldDefsForFile.FirstOrDefault(def => def.FieldName == RowData[index].FieldId));
		}

		/// ------------------------------------------------------------------------------------
		public bool IsIndexForCustomField(int index)
		{
			var fieldDef = GetFieldDefinitionForIndex(index);
			return (fieldDef == null || fieldDef.IsCustom);
		}

		/// ------------------------------------------------------------------------------------
		public bool IsIndexForReadOnlyField(int index)
		{
			var fieldDef = GetFieldDefinitionForIndex(index);
			return (fieldDef != null && fieldDef.ReadOnly);
		}

		/// ------------------------------------------------------------------------------------
		public bool CanDeleteRow(int index, out int indexToDelete)
		{
			indexToDelete = (index < RowData.Count ? index : -1);
			return IsIndexForCustomField(index);
		}

		/// ------------------------------------------------------------------------------------
		public string GetIdForIndex(int index)
		{
			return (index < RowData.Count ? RowData[index].FieldId : null);
		}

		/// ------------------------------------------------------------------------------------
		public string GetValueForIndex(int index)
		{
			return (index < RowData.Count ? RowData[index].Value : null);
		}

		/// ------------------------------------------------------------------------------------
		public void SaveIdForIndex(string id, int index)
		{
			id = id.Trim().Replace(' ', '_');

			if (index == RowData.Count)
				RowData.Add(new FieldInstance(id));
			else if (RowData[index].FieldId != id && _file.RenameId(RowData[index].FieldId, id))
			{
				RowData[index].FieldId = id;
				_file.Save();
			}
		}

		/// ------------------------------------------------------------------------------------
		public void SaveValueForIndex(string value, int index)
		{
			value = (value != null ? value.Trim() : string.Empty);

			if (value == RowData[index].Value)
				return;

			string failureMessage;
			value = _file.SetValue(RowData[index].FieldId, value, out failureMessage);
			if (failureMessage != null)
				Palaso.Reporting.ErrorReport.NotifyUserOfProblem(failureMessage);
			else
				RowData[index].Value = value;

			_file.Save();
		}

		/// ------------------------------------------------------------------------------------
		public void RemoveFieldForIndex(int index)
		{
			if (_file.RemoveField(RowData[index].FieldId))
			{
				RowData.RemoveAt(index);
				_file.Save();
			}
		}

		/// ------------------------------------------------------------------------------------
		public void SaveFieldForIndex(int index)
		{
			//// Don't bother doing anything if the old value is the same as the new value.
			//if (RowData[index].Value.FieldId == RowData[index].Key.FieldName)
			//    return;

			//var oldFieldValue = _file.MetaDataFieldValues.Find(x => x.FieldId == RowData[index].Key.FieldName);
			//if (oldFieldValue != null)
			//    _file.MetaDataFieldValues.Remove(oldFieldValue);

			//string failureMessage;

			//var newFieldValue = RowData[index].Value;
			//_file.SetValue(newFieldValue, out failureMessage);

			//if (failureMessage != null)
			//    Palaso.Reporting.ErrorReport.NotifyUserOfProblem(failureMessage);
			//else
			//    RowData[index].Key.FieldName = newFieldValue.FieldId;

			//_file.Save();
		}
	}
}
