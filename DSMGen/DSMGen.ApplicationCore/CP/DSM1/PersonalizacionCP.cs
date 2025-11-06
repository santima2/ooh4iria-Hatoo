
using System;
using System.Text;
using System.Collections.Generic;
using DSMGen.ApplicationCore.Exceptions;
using DSMGen.ApplicationCore.EN.DSM1;
using DSMGen.ApplicationCore.IRepository.DSM1;
using DSMGen.ApplicationCore.CEN.DSM1;
using DSMGen.ApplicationCore.Utils;



namespace DSMGen.ApplicationCore.CP.DSM1
{
public partial class PersonalizacionCP : GenericBasicCP
{
public PersonalizacionCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public PersonalizacionCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
