class A
	def do_work
		puts "A.do_work"
		yield
	end
end

class B < A
	def do_work
		puts "B.do_work"
		super
	end
end

b = B.new
b.do_work {
	puts "code block"
}

gets