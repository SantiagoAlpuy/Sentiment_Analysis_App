﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.IControllers
{
    public interface IAuthorController
    {
        void AddAuthor(Author author);
        Author ObtainAuthorByUsername(string username);
    }
}
