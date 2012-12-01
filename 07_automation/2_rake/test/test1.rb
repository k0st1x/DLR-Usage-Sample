require 'minitest/autorun'
require 'RbProcess'

describe RbProcess do
	before do
		@process = RbProcess.new
	end
 
	describe "notepad opened" do
		it "should open" do
			@process.start "cmd.exe"
			processes = @process.enumerate_all
			processes.must_include "C:\\Windows\\System32\\cmd.exe"
		end
	end
end
