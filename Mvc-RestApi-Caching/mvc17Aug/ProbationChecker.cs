using Microsoft.AspNetCore.Authorization;

namespace mvc17Aug
{
    public class ProbationChecker : IAuthorizationRequirement
    {
        public int probationMonths { get; }
        public ProbationChecker(int probationMonths)
        {
            this.probationMonths = probationMonths;
        }
    }

    public class EmployeementDateAuthorizationHandler : AuthorizationHandler<ProbationChecker>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProbationChecker requirement)
        {
            if (!context.User.HasClaim(x => x.Type == "EmploymentDate"))
                return Task.CompletedTask;

            var empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == "EmploymentDate").Value);
            var period = DateTime.Now - empDate;
            if (period.Days > 30 * requirement.probationMonths)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
