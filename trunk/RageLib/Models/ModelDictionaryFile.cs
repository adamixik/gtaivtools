/**********************************************************************\

 RageLib
 Copyright (C) 2008  Arushan/Aru <oneforaru at gmail.com>

 This program is free software: you can redistribute it and/or modify
 it under the terms of the GNU General Public License as published by
 the Free Software Foundation, either version 3 of the License, or
 (at your option) any later version.

 This program is distributed in the hope that it will be useful,
 but WITHOUT ANY WARRANTY; without even the implied warranty of
 MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 GNU General Public License for more details.

 You should have received a copy of the GNU General Public License
 along with this program.  If not, see <http://www.gnu.org/licenses/>.

\**********************************************************************/

using System.IO;
using RageLib.Models.Data;
using RageLib.Models.Resource;
using RageLib.Textures;

namespace RageLib.Models
{
    public class ModelDictionaryFile : IModelFile
    {
        internal File<DrawableModelDictionary> File { get; private set; }

        public void Open(string filename)
        {
            File = new File<DrawableModelDictionary>();
            File.Open(filename);
        }

        public void Open(Stream stream)
        {
            File = new File<DrawableModelDictionary>();
            File.Open(stream);
        }

        public ModelNode GetModel(TextureFile textures)
        {
            return ModelGenerator.GenerateModel(File.Data, textures);
        }

        public int ModelsInDictionary
        {
            get { return File.Data.Entries.Count; }
        }

        public Drawable GetDataModel(int modelIndex)
        {
            return new Drawable(File.Data.Entries[modelIndex]);
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            if (File != null)
            {
                File.Dispose();
                File = null;
            }
        }

        #endregion
    }
}