using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.infrastructure;
using Rhino.Mocks;


namespace nothinbutdotnetstore.specs.web
{
    public class ViewDepartmentsInDepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                          ViewDepartmentsinDepartment>
        {
        }

        [Subject(typeof(ViewDepartmentsinDepartment))]
        public class when_processing : concern
        {
            Establish c = () =>
            {
                response_engine = the_dependency<ResponseEngine>();
                department_repository = the_dependency<Repository>();
                the_departments = new List<Department>();
                request = an<Request>();

                department_repository.Stub(x => x.get_all_the__departments_in_the_department()).Return(
                    the_departments);
            };

            Because b = () =>
                sut.process(request);

            It Should_tell_Departments_in_Department_In_Stores = () =>
                response_engine.received(x => x.prepare(the_departments));

            static Repository department_repository;
            static Request request;
            static IEnumerable<Department> the_departments;
            static ResponseEngine response_engine;
        }
    }
}
