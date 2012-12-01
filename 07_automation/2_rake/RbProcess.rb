load_assembly 'UIAutomationClient'
load_assembly 'UIAutomationTypes'
include System::Windows::Automation

class RbProcess
	def start(name)
		System::Diagnostics::Process.start name
		System::Threading::Thread.Sleep 1500
	end
	
	def enumerate_all
		tops = AutomationElement.RootElement.FindAll(TreeScope.Children, Condition.TrueCondition)
		tops.map {|elem| 
			elem.GetCurrentPropertyValue(AutomationElement.NameProperty)
		}
	end
end